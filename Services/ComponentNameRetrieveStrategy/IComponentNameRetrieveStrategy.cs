using Emmetienne.SolutionReplicator.Model;
using Microsoft.Xrm.Sdk;

namespace Emmetienne.SolutionReplicator.Services.ComponentNameRetrieveStrategy
{
    interface IComponentNameRetrieveStrategy
    {
        void Handle(SolutionComponentWrapper componentToSearchForName,
                                  IOrganizationService organizationService,
                                  LogService logService);
    }
}
