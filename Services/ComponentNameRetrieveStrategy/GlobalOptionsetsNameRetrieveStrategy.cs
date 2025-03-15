using Emmetienne.SolutionReplicator.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;

namespace Emmetienne.SolutionReplicator.Services.ComponentNameRetrieveStrategy
{
    internal class GlobalOptionsetsNameRetrieveStrategy : IComponentNameRetrieveStrategy
    {
        public void Handle(SolutionComponentWrapper componentToSearchForName, IOrganizationService organizationService, LogService logService)
        {
            var sourceEnvironmentRetrieveAttributeRequest = new RetrieveOptionSetRequest
            {
                MetadataId = componentToSearchForName.ObjectId
            };

            var sourceRetrieveResponse = (RetrieveOptionSetResponse)organizationService.Execute(sourceEnvironmentRetrieveAttributeRequest);

            componentToSearchForName.ComponentName = sourceRetrieveResponse.OptionSetMetadata.Name;
        }
    }
}
