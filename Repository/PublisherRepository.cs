using Emmetienne.SolutionReplicator.Model.Entities;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;

namespace Emmetienne.SolutionReplicator.Repository
{
    internal class PublisherRepository
    {
        private IOrganizationService organizationService;
        private LogService logger;

        public PublisherRepository(IOrganizationService organizationService, LogService logger)
        {
            this.organizationService = organizationService;
            this.logger = logger;
        }

        public List<Entity> GetEnvironmentPublishers()
        {
            logger.LogInfo("Retrieving publishers for the target environment");

            var publisherQuery = new QueryExpression(nameof(publisher));
            publisherQuery.NoLock = true;
            publisherQuery.ColumnSet.AddColumns(publisher.customizationprefix, publisher.uniquename, publisher.friendlyname);

            return organizationService.RetrieveMultiple(publisherQuery).Entities.ToList();
        }
    }
}
