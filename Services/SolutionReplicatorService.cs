using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Model.Entities;
using Emmetienne.SolutionReplicator.Repository;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using XrmToolBox.Extensibility;

namespace Emmetienne.SolutionReplicator.Services
{
    internal class SolutionReplicatorService
    {
        private readonly LogService logService;
        private readonly IOrganizationService sourceEnnvironmentService;
        private readonly IOrganizationService targetEnvironmentService;
        private readonly Worker xrmToolboxWorker;
        private readonly PluginControlBase pluginControlBase;
        private readonly SolutionComponentsRepository solutionComponentRepository;
        private readonly SolutionRepository solutionRepository;

        public SolutionReplicatorService(LogService logService, IOrganizationService sourceEnvironmentService, IOrganizationService targetEnvironmentService, Worker xrmToolboxWorker, PluginControlBase pluginControlBase)
        {
            this.logService = logService;
            this.sourceEnnvironmentService = sourceEnvironmentService;
            this.targetEnvironmentService = targetEnvironmentService;
            this.xrmToolboxWorker = xrmToolboxWorker;
            this.pluginControlBase = pluginControlBase;

            this.solutionComponentRepository = new SolutionComponentsRepository(targetEnvironmentService, logService);
            this.solutionRepository = new SolutionRepository(targetEnvironmentService, logService);
        }



        public void ReplicateSolution(List<SolutionComponentWrapper> solutionComponents, TargetSolutionSettings targetSolutionSettings)
        {
            pluginControlBase.WorkAsync(new WorkAsyncInfo
            {
                Message = "Searching component on target environment",
                Work = (worker, args) =>
                {
                    EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(true);

                    var foundAndNotFoundComponents = GetNotFoundComponents(solutionComponents);

                    worker.ReportProgress(0, $"Creating solution on target environment");

                    var createdSolutionData = solutionRepository.CreateSolution(targetSolutionSettings);

                    var componentCounter = 1;
                    foreach (var component in foundAndNotFoundComponents.FoundComponents.OrderBy(x => x.ComponentType))
                    {
                        worker.ReportProgress(0, $"Adding component to target solution {Environment.NewLine} {componentCounter++}/{foundAndNotFoundComponents.FoundComponents.Count}");

                        if (component.TargetEnvironmentObjectId.HasValue)
                        {
                            solutionRepository.AddComponentToSolution(component.TargetEnvironmentObjectId.Value, component.ComponentType, createdSolutionData.UniqueName, component.RootComponentBehaviour);
                            continue;
                        }

                        solutionRepository.AddComponentToSolution(component.ObjectId, component.ComponentType, createdSolutionData.UniqueName, component.RootComponentBehaviour);
                    }
                },
                ProgressChanged = (args) =>
                {
                    pluginControlBase.SetWorkingMessage(args.UserState.ToString());
                },
                PostWorkCallBack = (args) =>
                {
                    EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(false);
                }
            });
        }

        private void PruneAutoaddedComponents(FoundAndNotFoundComponents foundAndNotFoundComponents, SolutionRepository solutionRepository, SolutionWrapper createdSolutionData)
        {
            var createdSolutionComponentQuery = new QueryExpression(nameof(solutioncomponent));
            createdSolutionComponentQuery.NoLock = true;
            createdSolutionComponentQuery.ColumnSet.AddColumns(solutioncomponent.objectid, solutioncomponent.componenttype);

            createdSolutionComponentQuery.Criteria.AddCondition(solutioncomponent.solutionid, ConditionOperator.Equal, createdSolutionData.SolutionId);

            var targetSolutionComponentResults = targetEnvironmentService.RetrieveMultiple(createdSolutionComponentQuery);

            foreach (var component in targetSolutionComponentResults.Entities)
            {
                var objectId = component.GetAttributeValue<Guid>(solutioncomponent.objectid);
                var componentType = component.GetAttributeValue<OptionSetValue>(solutioncomponent.componenttype).Value;

                var foundComponent = foundAndNotFoundComponents.FoundComponents.FirstOrDefault(x => x.ObjectId == objectId);

                if (foundComponent != null)
                    continue;

                solutionRepository.RemoveComponentToSolution(objectId, componentType, createdSolutionData.UniqueName);
            }
        }
        private FoundAndNotFoundComponents GetNotFoundComponents(List<SolutionComponentWrapper> notFoundComponents)
        {
            pluginControlBase.SetWorkingMessage($"Searching components not found on target environment");

            var notFoundSolutionComponentsGroupedByComponentType = notFoundComponents.GroupBy(x => x.ComponentType).OrderBy(x => x.Key);

            var goodAndBadComponents = new FoundAndNotFoundComponents();

            foreach (var group in notFoundSolutionComponentsGroupedByComponentType)
            {
                pluginControlBase.SetWorkingMessage($"Searching components of type {ComponentTypeCache.Instance.GetComponentTypeNameFromComponentType(group.Key)} not found on target environment");

                // try to handle peculiar cases involving metatdata
                switch (group.Key)
                {
                    case 1:
                        goodAndBadComponents.AddGoodAndBadcomponents(RetrieveEntities(group));
                        continue;
                    case 2:
                        goodAndBadComponents.AddGoodAndBadcomponents(RetrieveAttributes(group));
                        continue;
                    case 9:
                        goodAndBadComponents.AddGoodAndBadcomponents(RetrieveGlobalOptionsets(group));
                        continue;
                    case 10:
                        goodAndBadComponents.AddGoodAndBadcomponents(RetrieveEntityRelationships(group));
                        continue;
                    case 14:
                        goodAndBadComponents.AddGoodAndBadcomponents(RetrieveEntityKeys(group));
                        continue;
                    default:
                        break;
                }

                if (!ComponentTypeCache.Instance.ContainsKey(group.Key))
                    continue;

                goodAndBadComponents.AddGoodAndBadcomponents(RetrieveGenericSolutionComponent(group, group.Key,
                                            ComponentTypeCache.Instance.GetComponentTypeFromComponentTypeCode(group.Key)));
            }

            return goodAndBadComponents;
        }

        private FoundAndNotFoundComponents RetrieveGenericSolutionComponent(IEnumerable<SolutionComponentWrapper> attributesComponentsTypeToSearch, int componentType, ComponentType componentTypeContent)
        {
            var goodAndBadComponents = new FoundAndNotFoundComponents();

            if (componentTypeContent.DoNotAddToSolution)
            {
                return goodAndBadComponents;
            }

            foreach (var component in attributesComponentsTypeToSearch)
            {
                var primaryKeyLogicalName = !string.IsNullOrWhiteSpace(componentTypeContent.ComponentPrimaryKeyLogicalName) ? componentTypeContent.ComponentPrimaryKeyLogicalName : $"{componentTypeContent.ComponentEntityLogicalName}id";

                var sourceEnvEntityQuery = new QueryExpression(componentTypeContent.ComponentEntityLogicalName);
                sourceEnvEntityQuery.NoLock = true;
                sourceEnvEntityQuery.ColumnSet.AddColumns(componentTypeContent.ComponentPrimaryFieldLogicalName);

                sourceEnvEntityQuery.Criteria.AddCondition(primaryKeyLogicalName, ConditionOperator.Equal, component.ObjectId);


                if (componentTypeContent.AdditionalFieldsForComparisonList != null && componentTypeContent.AdditionalFieldsForComparisonList.Count > 0)
                {
                    sourceEnvEntityQuery.ColumnSet.AddColumns(componentTypeContent.AdditionalFieldsForComparisonList.Select(x => x.FieldName).ToArray());
                }

                var sourceResults = sourceEnnvironmentService.RetrieveMultiple(sourceEnvEntityQuery);

                if (sourceResults.Entities.Count == 0)
                {
                    goodAndBadComponents.NotFoundComponents.Add(component);
                    continue;
                }

                object comparisonFieldValue = null;

                if (componentTypeContent.ComponentPrimaryFieldType != null)
                {
                    var getSourceAttributeValueMethod = typeof(Entity).GetMethod(nameof(Entity.GetAttributeValue)).MakeGenericMethod(componentTypeContent.ComponentPrimaryFieldType);
                    comparisonFieldValue = getSourceAttributeValueMethod.Invoke(sourceResults.Entities[0], new object[] { componentTypeContent.ComponentPrimaryFieldLogicalName });
                }
                else
                    comparisonFieldValue = sourceResults.Entities[0].GetAttributeValue<string>(componentTypeContent.ComponentPrimaryFieldLogicalName);


                var targetEnvEntityQuery = new QueryExpression(componentTypeContent.ComponentEntityLogicalName);
                targetEnvEntityQuery.NoLock = true;

                targetEnvEntityQuery.Criteria.AddCondition(componentTypeContent.ComponentPrimaryFieldLogicalName, ConditionOperator.Equal, comparisonFieldValue);

                if (componentTypeContent.AdditionalFieldsForComparisonList != null && componentTypeContent.AdditionalFieldsForComparisonList.Count > 0)
                {
                    foreach (var additionalComponentFieldForComparison in componentTypeContent.AdditionalFieldsForComparisonList)
                    {
                        var getAttributeValueMethod = typeof(Entity).GetMethod(nameof(Entity.GetAttributeValue)).MakeGenericMethod(additionalComponentFieldForComparison.FieldType);
                        var dynamicValue = getAttributeValueMethod.Invoke(sourceResults.Entities[0], new object[] { additionalComponentFieldForComparison.FieldName });

                        if (dynamicValue is OptionSetValue optionset && optionset != null)
                        {
                            targetEnvEntityQuery.Criteria.AddCondition(additionalComponentFieldForComparison.FieldName, ConditionOperator.Equal, optionset.Value);
                            continue;
                        }

                        if (dynamicValue is EntityReference entityReference && entityReference != null)
                        {
                            targetEnvEntityQuery.Criteria.AddCondition(additionalComponentFieldForComparison.FieldName, ConditionOperator.Equal, entityReference.Id);
                            continue;
                        }

                        targetEnvEntityQuery.Criteria.AddCondition(additionalComponentFieldForComparison.FieldName, ConditionOperator.Equal, dynamicValue);
                    }
                }

                // this is needed to handle special cases
                // an example: with this code you can add only the roles that doesn't have a parent role
                // as they're the root roles
                if (componentTypeContent.NullFieldsForComparisonList != null && componentTypeContent.NullFieldsForComparisonList.Count > 0)
                {
                    foreach (var nullField in componentTypeContent.NullFieldsForComparisonList)
                    {
                        targetEnvEntityQuery.Criteria.AddCondition(nullField, ConditionOperator.Null);
                    }
                }

                var targetResults = targetEnvironmentService.RetrieveMultiple(targetEnvEntityQuery);

                if (targetResults.Entities.Count == 0)
                {
                    goodAndBadComponents.NotFoundComponents.Add(component);
                    continue;
                }

                foreach (var result in targetResults.Entities)
                {
                    var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                    tmpTargetComponentWrapper.ObjectId = result.Id;

                    tmpTargetComponentWrapper.ComponentType = componentTypeContent.TargetComponentTypeCode.HasValue ? componentTypeContent.TargetComponentTypeCode.Value : componentType;
                    goodAndBadComponents.FoundComponents.Add(tmpTargetComponentWrapper);
                }
            }

            return goodAndBadComponents;
        }

        private FoundAndNotFoundComponents RetrieveEntities(IEnumerable<SolutionComponentWrapper> attributesComponentsTypeToSearch)
        {
            var goodAndBadComponents = new FoundAndNotFoundComponents();

            foreach (var component in attributesComponentsTypeToSearch)
            {
                var sourceEnvEntityQuery = new QueryExpression("entity");
                sourceEnvEntityQuery.NoLock = true;
                sourceEnvEntityQuery.ColumnSet.AddColumns("logicalname");

                sourceEnvEntityQuery.Criteria.AddCondition("entityid", ConditionOperator.Equal, component.ObjectId);

                var results = sourceEnnvironmentService.RetrieveMultiple(sourceEnvEntityQuery);

                if (results.Entities.Count == 0)
                {
                    goodAndBadComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var entityLogicalName = results.Entities[0].GetAttributeValue<string>("logicalname");

                var targetEnvEntityQuery = new QueryExpression("entity");
                targetEnvEntityQuery.NoLock = true;
                targetEnvEntityQuery.Criteria.AddCondition("logicalname", ConditionOperator.Equal, entityLogicalName);

                var targetResults = targetEnvironmentService.RetrieveMultiple(targetEnvEntityQuery);

                if (targetResults.Entities.Count == 0)
                {
                    goodAndBadComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                tmpTargetComponentWrapper.ObjectId = targetResults.Entities[0].Id;
                tmpTargetComponentWrapper.ComponentType = 1;
                goodAndBadComponents.FoundComponents.Add(tmpTargetComponentWrapper);
            }

            return goodAndBadComponents;
        }

        private FoundAndNotFoundComponents RetrieveAttributes(IEnumerable<SolutionComponentWrapper> attributesComponentsTypeToSearch)
        {
            var goodAndBadComponents = new FoundAndNotFoundComponents();

            foreach (var component in attributesComponentsTypeToSearch)
            {
                var sourceEnvironmentRetrieveAttributeRequest = new RetrieveAttributeRequest
                {
                    MetadataId = component.ObjectId
                };

                var sourceRetrieveResponse = (RetrieveAttributeResponse)sourceEnnvironmentService.Execute(sourceEnvironmentRetrieveAttributeRequest);

                if (sourceRetrieveResponse.AttributeMetadata == null)
                {
                    goodAndBadComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var entityLogicalName = sourceRetrieveResponse.AttributeMetadata.EntityLogicalName;
                var attributeSchemaName = sourceRetrieveResponse.AttributeMetadata.LogicalName;

                var targetEnvironmentRetrieveAttributeRequest = new RetrieveAttributeRequest
                {
                    EntityLogicalName = entityLogicalName,
                    LogicalName = attributeSchemaName
                };

                try
                {
                    var targetRetrieveResponse = (RetrieveAttributeResponse)targetEnvironmentService.Execute(targetEnvironmentRetrieveAttributeRequest);

                    if (targetRetrieveResponse.AttributeMetadata == null)
                    {
                        goodAndBadComponents.NotFoundComponents.Add(component);
                        continue;
                    }

                    var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                    tmpTargetComponentWrapper.TargetEnvironmentObjectId = targetRetrieveResponse.AttributeMetadata.MetadataId.Value;
                    tmpTargetComponentWrapper.ObjectId = component.ObjectId;
                    tmpTargetComponentWrapper.ComponentType = 2;
                    goodAndBadComponents.FoundComponents.Add(tmpTargetComponentWrapper);
                }
                catch (Exception ex)
                {
                    logService.LogError($"Error while retrieving attribute {attributeSchemaName} for entity {entityLogicalName} - {ex.Message}");
                }
            }

            return goodAndBadComponents;
        }

        private FoundAndNotFoundComponents RetrieveGlobalOptionsets(IEnumerable<SolutionComponentWrapper> attributesComponentsTypeToSearch)
        {
            var goodAndBadComponents = new FoundAndNotFoundComponents();

            foreach (var component in attributesComponentsTypeToSearch)
            {
                var sourceEnvironmentRetrieveAttributeRequest = new RetrieveOptionSetRequest
                {
                    MetadataId = component.ObjectId
                };

                var sourceRetrieveResponse = (RetrieveOptionSetResponse)sourceEnnvironmentService.Execute(sourceEnvironmentRetrieveAttributeRequest);

                if (sourceRetrieveResponse.OptionSetMetadata == null)
                {
                    goodAndBadComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var optionSetLogicalName = sourceRetrieveResponse.OptionSetMetadata.Name;

                var targetEnvironmentRetrieveAttributeRequest = new RetrieveOptionSetRequest
                {
                    Name = optionSetLogicalName
                };

                try
                {
                    var targetRetrieveResponse = (RetrieveOptionSetResponse)targetEnvironmentService.Execute(targetEnvironmentRetrieveAttributeRequest);

                    if (sourceRetrieveResponse.OptionSetMetadata == null)
                    {
                        goodAndBadComponents.NotFoundComponents.Add(component);
                        continue;
                    }


                    var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                    tmpTargetComponentWrapper.TargetEnvironmentObjectId = targetRetrieveResponse.OptionSetMetadata.MetadataId.Value;
                    tmpTargetComponentWrapper.ObjectId = component.ObjectId;
                    tmpTargetComponentWrapper.ComponentType = 9;
                    goodAndBadComponents.FoundComponents.Add(tmpTargetComponentWrapper);
                }
                catch (Exception ex)
                {
                    logService.LogError($"Error while retrieving optionset {optionSetLogicalName} - {ex.Message}");
                    continue;
                }

            }
            return goodAndBadComponents;
        }

        private FoundAndNotFoundComponents RetrieveEntityRelationships(IEnumerable<SolutionComponentWrapper> attributesComponentsTypeToSearch)
        {
            var goodAndBadComponents = new FoundAndNotFoundComponents();

            foreach (var component in attributesComponentsTypeToSearch)
            {
                var sourceEnvironmentRetrieveAttributeRequest = new RetrieveRelationshipRequest
                {
                    MetadataId = component.ObjectId
                };

                var sourceRetrieveResponse = (RetrieveRelationshipResponse)sourceEnnvironmentService.Execute(sourceEnvironmentRetrieveAttributeRequest);

                if (sourceRetrieveResponse.RelationshipMetadata == null)
                {
                    goodAndBadComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var entityRelationshipSchemaName = sourceRetrieveResponse.RelationshipMetadata.SchemaName;

                var targetEnvironmentRetrieveAttributeRequest = new RetrieveRelationshipRequest
                {
                    Name = entityRelationshipSchemaName
                };

                try { 
                var targetRetrieveResponse = (RetrieveRelationshipResponse)targetEnvironmentService.Execute(targetEnvironmentRetrieveAttributeRequest);

                if (sourceRetrieveResponse.RelationshipMetadata == null)
                {
                    goodAndBadComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                tmpTargetComponentWrapper.TargetEnvironmentObjectId = targetRetrieveResponse.RelationshipMetadata.MetadataId.Value;
                tmpTargetComponentWrapper.ObjectId = component.ObjectId;
                tmpTargetComponentWrapper.ComponentType = 10;
                goodAndBadComponents.FoundComponents.Add(tmpTargetComponentWrapper);
                }
                catch  (Exception ex)
                {
                    logService.LogError($"Error while retrieving relationship {entityRelationshipSchemaName} - {ex.Message}");
                }

                return goodAndBadComponents;
            }

            return goodAndBadComponents;
        }

        private FoundAndNotFoundComponents RetrieveEntityKeys(IEnumerable<SolutionComponentWrapper> attributesComponentsTypeToSearch)
        {
            var goodAndBadComponents = new FoundAndNotFoundComponents();

            foreach (var component in attributesComponentsTypeToSearch)
            {
                var sourceEnvironmentRetrieveAttributeRequest = new RetrieveEntityKeyRequest
                {
                    MetadataId = component.ObjectId
                };

                var sourceRetrieveResponse = (RetrieveEntityKeyResponse)sourceEnnvironmentService.Execute(sourceEnvironmentRetrieveAttributeRequest);

                if (sourceRetrieveResponse.EntityKeyMetadata == null)
                {
                    goodAndBadComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var entityKeyLogicalName = sourceRetrieveResponse.EntityKeyMetadata.LogicalName;

                var targetEnvironmentRetrieveAttributeRequest = new RetrieveEntityKeyRequest
                {
                    LogicalName = entityKeyLogicalName
                };


                var targetRetrieveResponse = (RetrieveEntityKeyResponse)targetEnvironmentService.Execute(targetEnvironmentRetrieveAttributeRequest);

                if (sourceRetrieveResponse.EntityKeyMetadata == null)
                {
                    goodAndBadComponents.NotFoundComponents.Add(component);
                    continue;
                }


                var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                tmpTargetComponentWrapper.TargetEnvironmentObjectId = targetRetrieveResponse.EntityKeyMetadata.MetadataId.Value;
                tmpTargetComponentWrapper.ObjectId = component.ObjectId;
                tmpTargetComponentWrapper.ComponentType = 14;
                goodAndBadComponents.FoundComponents.Add(tmpTargetComponentWrapper);
            }

            return goodAndBadComponents;
        }
    }
}
