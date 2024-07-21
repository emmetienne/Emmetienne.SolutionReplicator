using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emmetienne.SolutionReplicator.ComponentSearchServiceStrategy.Strategy
{
    internal class GenericComponentSearchStrategy : IComponentSearchStrategy
    {
        public FoundAndNotFoundComponents Handle(IEnumerable<SolutionComponentWrapper> componentToSearchList, IOrganizationService sourceEnvironmentService, IOrganizationService targetEnvironmentService, LogService logService)
        {
            var foundAndNotFoundComponents = new FoundAndNotFoundComponents();

            var componentType = componentToSearchList.First().ComponentType;

            var componentTypeContent = ComponentTypeCache.Instance.GetComponentTypeFromComponentTypeCode(componentType);

            if (componentTypeContent.DoNotAddToSolution)
            {
                return foundAndNotFoundComponents;
            }

            foreach (var component in componentToSearchList)
            {
                try
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

                    var sourceResults = sourceEnvironmentService.RetrieveMultiple(sourceEnvEntityQuery);

                    if (sourceResults.Entities.Count == 0)
                    {
                        foundAndNotFoundComponents.NotFoundComponents.Add(component);
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
                        component.ComponentSearchResult = ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.notFoundOnTargetEnvironment];
                        foundAndNotFoundComponents.NotFoundComponents.Add(component);

                        logService.LogWarning($"Component of type {component.ComponentTypeName} with source environment id <{component.ObjectId}> not found on target environment");
                        continue;
                    }

                    if (targetResults.Entities.Count > 1)
                        logService.LogWarning($"Component of type {component.ComponentTypeName} with source environment id <{component.ObjectId}> found multiple times on target environment, both will be added to the solution");

                    foreach (var result in targetResults.Entities)
                    {
                        var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                        tmpTargetComponentWrapper.TargetEnvironmentObjectId = result.Id;
                        tmpTargetComponentWrapper.ObjectId = component.ObjectId;

                        tmpTargetComponentWrapper.ComponentType = componentTypeContent.TargetComponentTypeCode.HasValue ? componentTypeContent.TargetComponentTypeCode.Value : componentType;

                        tmpTargetComponentWrapper.ComponentSearchResult = targetResults.Entities.Count > 1 ? ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.foundMultipleOnTargetEnvironment] : ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.foundOnTargetEnvironment];

                        foundAndNotFoundComponents.FoundComponents.Add(tmpTargetComponentWrapper);
                    }
                }
                catch (Exception ex)
                {
                    logService.LogError($"Error while searching component {component.ObjectId} of type {componentType}", ex.Message);
                    component.ComponentSearchResult = ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.error];
                    foundAndNotFoundComponents.NotFoundComponents.Add(component);
                }
            }

            return foundAndNotFoundComponents;
        }
    }
}
