using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;

namespace Emmetienne.SolutionReplicator.Repository
{
    internal class SolutionComponentTypesRepository
    {
        private IOrganizationService organizationService;
        private LogService logger;

        public SolutionComponentTypesRepository(IOrganizationService organizationService, LogService logger)
        {
            this.organizationService = organizationService;
            this.logger = logger;
        }

        public OptionSetMetadata GetComponentTypesFromEnvironment()
        {
            logger.LogInfo("Retrieving solution components from environment");
            var componentTypeOptionSetQuery = new RetrieveOptionSetRequest { Name = "componenttype" };

            var componentTypeQueryResult = (RetrieveOptionSetResponse)organizationService.Execute(componentTypeOptionSetQuery);
            return (OptionSetMetadata)componentTypeQueryResult.OptionSetMetadata;
        }
    }
}
