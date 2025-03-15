using Emmetienne.SolutionReplicator.Model;
using Microsoft.Xrm.Sdk;

namespace Emmetienne.SolutionReplicator.Services.ComponentNameRetrieveStrategy
{
    internal class NotYetImplementedComponentNameRetrieve : IComponentNameRetrieveStrategy
    {
        public void Handle(SolutionComponentWrapper componentToSearchForName, IOrganizationService organizationService, LogService logService)
        {
            logService.LogError($"Component name retrieve for type {componentToSearchForName.ComponentType} currently not handled by this plugin");
        }
    }
}

