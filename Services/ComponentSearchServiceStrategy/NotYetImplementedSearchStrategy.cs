using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.ComponentSearchServiceStrategy.Strategy
{
    internal class NotYetImplementedSearchStrategy : IComponentSearchStrategy
    {
        public FoundAndNotFoundComponents Handle(IEnumerable<SolutionComponentWrapper> componentToSearchList, IOrganizationService sourceEnvironmentService, IOrganizationService targetEnvironmentService, LogService logService)
        {
            var foundAndNotFoundComponents = new FoundAndNotFoundComponents();

            foreach (var component in componentToSearchList)
            {
                component.ComponentSearchResult = ComponentSearchResult.searchResultOptionDictionary[SolutionComponentSearchResult.notYetHandled];
                foundAndNotFoundComponents.NotFoundComponents.Add(component);

                logService.LogError($"Component type {component.ComponentType} currently not handled by this plugin");
            }

            return foundAndNotFoundComponents;
        }
    }
}

