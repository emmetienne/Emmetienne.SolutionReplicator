using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using System;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.ComponentSearchServiceStrategy.Strategy
{
    internal class GlobalOptionsetsSearchStrategy : IComponentSearchStrategy
    {
        public FoundAndNotFoundComponents Handle(IEnumerable<SolutionComponentWrapper> componentToSearchList, IOrganizationService sourceEnvironmentService, IOrganizationService targetEnvironmentService, LogService logService)
        {
            var foundAndNotFoundComponents = new FoundAndNotFoundComponents();

            foreach (var component in componentToSearchList)
            {
                var sourceEnvironmentRetrieveAttributeRequest = new RetrieveOptionSetRequest
                {
                    MetadataId = component.ObjectId
                };

                var sourceRetrieveResponse = (RetrieveOptionSetResponse)sourceEnvironmentService.Execute(sourceEnvironmentRetrieveAttributeRequest);

                if (sourceRetrieveResponse.OptionSetMetadata == null)
                {
                    foundAndNotFoundComponents.NotFoundComponents.Add(component);
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

                    if (targetRetrieveResponse.OptionSetMetadata == null)
                    {
                        component.ComponentSearchResult = ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.notFoundOnTargetEnvironment];
                        foundAndNotFoundComponents.NotFoundComponents.Add(component);
                        continue;
                    }

                    var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                    tmpTargetComponentWrapper.TargetEnvironmentObjectId = targetRetrieveResponse.OptionSetMetadata.MetadataId.Value;
                    tmpTargetComponentWrapper.ObjectId = component.ObjectId;
                    tmpTargetComponentWrapper.ComponentType = 9;
                    tmpTargetComponentWrapper.ComponentSearchResult = ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.foundOnTargetEnvironment];

                    foundAndNotFoundComponents.FoundComponents.Add(tmpTargetComponentWrapper);
                }
                catch (Exception ex)
                {
                    logService.LogError($"Error while retrieving optionset {optionSetLogicalName}", ex.Message);
                    component.ComponentSearchResult = ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.notFoundOnTargetEnvironment];
                    foundAndNotFoundComponents.NotFoundComponents.Add(component);
                }
            }

            return foundAndNotFoundComponents;
        }
    }
}
