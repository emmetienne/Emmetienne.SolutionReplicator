using Emmetienne.SolutionReplicator.Model.Entities;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System.Collections.Generic;
using System.Linq;

namespace Emmetienne.SolutionReplicator.Repository
{
    internal class SolutionComponentsDefinitionsRepository
    {
        private IOrganizationService organizationService;

        public SolutionComponentsDefinitionsRepository(IOrganizationService organizationService)
        {
            this.organizationService = organizationService;
        }

        public List<Entity> GetSolutionComponentDefinitions()
        {
            var solutionComponentDefinitionQuery = new QueryExpression(nameof(solutioncomponentdefinition));
            solutionComponentDefinitionQuery.NoLock = true;
            solutionComponentDefinitionQuery.ColumnSet.AddColumns(solutioncomponentdefinition.solutioncomponenttype, solutioncomponentdefinition.primaryentityname, solutioncomponentdefinition.name);

            return organizationService.RetrieveMultiple(solutionComponentDefinitionQuery).Entities.ToList();
        }
    }
}
