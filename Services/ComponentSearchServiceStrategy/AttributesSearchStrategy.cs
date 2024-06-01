using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.ComponentSearchServiceStrategy.Strategy
{
    internal class AttributesSearchStrategy : IComponentSearchStrategy
    {
        public FoundAndNotFoundComponents Handle(IEnumerable<SolutionComponentWrapper> componentToSearchList, IOrganizationService sourceEnvironmentService, IOrganizationService targetEnvironmentService, LogService logService)
        {
            var foundAndNotFoundComponents = new FoundAndNotFoundComponents();

            foreach (var component in componentToSearchList)
            {
                var sourceEnvironmentRetrieveAttributeRequest = new RetrieveAttributeRequest
                {
                    MetadataId = component.ObjectId
                };

                var sourceRetrieveResponse = (RetrieveAttributeResponse)sourceEnvironmentService.Execute(sourceEnvironmentRetrieveAttributeRequest);

                if (sourceRetrieveResponse.AttributeMetadata == null)
                {
                    foundAndNotFoundComponents.NotFoundComponents.Add(component);
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
                        foundAndNotFoundComponents.NotFoundComponents.Add(component);
                        continue;
                    }

                    var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                    tmpTargetComponentWrapper.TargetEnvironmentObjectId = targetRetrieveResponse.AttributeMetadata.MetadataId.Value;
                    tmpTargetComponentWrapper.ObjectId = component.ObjectId;
                    tmpTargetComponentWrapper.ComponentType = 2;
                    foundAndNotFoundComponents.FoundComponents.Add(tmpTargetComponentWrapper);
                }
                catch (Exception ex)
                {
                    logService.LogError($"Error while retrieving attribute {attributeSchemaName} for entity {entityLogicalName}", ex.Message);
                }
            }

            return foundAndNotFoundComponents;
        }

    }
}

