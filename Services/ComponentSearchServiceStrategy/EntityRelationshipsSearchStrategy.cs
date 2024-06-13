using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.ComponentSearchServiceStrategy.Strategy
{
    internal class EntityRelationshipsSearchStrategy : IComponentSearchStrategy
    {
        public FoundAndNotFoundComponents Handle(IEnumerable<SolutionComponentWrapper> componentToSearchList, IOrganizationService sourceEnvironmentService, IOrganizationService targetEnvironmentService, LogService logService)
        {
            var foundAndNotFoundComponents = new FoundAndNotFoundComponents();

            foreach (var component in componentToSearchList)
            {
                var sourceEnvironmentRetrieveAttributeRequest = new RetrieveRelationshipRequest
                {
                    MetadataId = component.ObjectId
                };

                var sourceRetrieveResponse = (RetrieveRelationshipResponse)sourceEnvironmentService.Execute(sourceEnvironmentRetrieveAttributeRequest);

                if (sourceRetrieveResponse.RelationshipMetadata == null)
                {
                    foundAndNotFoundComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var entityRelationshipSchemaName = sourceRetrieveResponse.RelationshipMetadata.SchemaName;

                var targetEnvironmentRetrieveAttributeRequest = new RetrieveRelationshipRequest
                {
                    Name = entityRelationshipSchemaName
                };

                try
                {
                    var targetRetrieveResponse = (RetrieveRelationshipResponse)targetEnvironmentService.Execute(targetEnvironmentRetrieveAttributeRequest);

                    if (sourceRetrieveResponse.RelationshipMetadata == null)
                    {
                        component.ComponentSearchResult = ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.notFoundOnTargetEnvironment];
                        foundAndNotFoundComponents.NotFoundComponents.Add(component);
                        continue;
                    }

                    var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                    tmpTargetComponentWrapper.TargetEnvironmentObjectId = targetRetrieveResponse.RelationshipMetadata.MetadataId.Value;
                    tmpTargetComponentWrapper.ObjectId = component.ObjectId;
                    tmpTargetComponentWrapper.ComponentSearchResult = ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.foundOnTargetEnvironment];


                    tmpTargetComponentWrapper.ComponentType = 10;

                    foundAndNotFoundComponents.FoundComponents.Add(tmpTargetComponentWrapper);
                }
                catch (Exception ex)
                {
                    logService.LogError($"Error while retrieving relationship {entityRelationshipSchemaName}", ex.Message);
                    component.ComponentSearchResult = ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.notFoundOnTargetEnvironment];
                    foundAndNotFoundComponents.NotFoundComponents.Add(component);
                }
            }

            return foundAndNotFoundComponents;
        }
    }
}
