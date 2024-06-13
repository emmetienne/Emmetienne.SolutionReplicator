using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.ComponentSearchServiceStrategy.Strategy
{
    internal interface IComponentSearchStrategy
    {
        FoundAndNotFoundComponents Handle(IEnumerable<SolutionComponentWrapper> componentToSearchList, 
                                          IOrganizationService sourceEnvironmentService,
                                          IOrganizationService targetEnvironmentService,
                                          LogService logService);
    }
}
