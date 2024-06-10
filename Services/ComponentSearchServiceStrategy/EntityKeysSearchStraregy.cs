using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.ComponentSearchServiceStrategy.Strategy
{
    internal class EntityKeysSearchStraregy : IComponentSearchStrategy
    {
        public FoundAndNotFoundComponents Handle(IEnumerable<SolutionComponentWrapper> componentToSearchList, IOrganizationService sourceEnvironmentService, IOrganizationService targetEnvironmentService, LogService logService)
        {
            var foundAndNotFoundComponents = new FoundAndNotFoundComponents();

            foreach (var component in componentToSearchList)
            {
                var sourceEnvironmentRetrieveAttributeRequest = new RetrieveEntityKeyRequest
                {
                    MetadataId = component.ObjectId
                };

                var sourceRetrieveResponse = (RetrieveEntityKeyResponse)sourceEnvironmentService.Execute(sourceEnvironmentRetrieveAttributeRequest);

                if (sourceRetrieveResponse.EntityKeyMetadata == null)
                {
                    foundAndNotFoundComponents.NotFoundComponents.Add(component);
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
                    component.ComponentSearchResult = ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.notFoundOnTargetEnvironment];
                    foundAndNotFoundComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                tmpTargetComponentWrapper.TargetEnvironmentObjectId = targetRetrieveResponse.EntityKeyMetadata.MetadataId.Value;
                tmpTargetComponentWrapper.ObjectId = component.ObjectId;
                tmpTargetComponentWrapper.ComponentType = 14;
                tmpTargetComponentWrapper.ComponentSearchResult =   ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.foundOnTargetEnvironment];

                foundAndNotFoundComponents.FoundComponents.Add(tmpTargetComponentWrapper);
            }

            return foundAndNotFoundComponents;
        }
    }
}
