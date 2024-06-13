using Emmetienne.SolutionReplicator.Model.Entities;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emmetienne.SolutionReplicator.Repository
{
    internal class SolutionComponentsRepository 
    {
        private IOrganizationService organizationService;
        private LogService logger;

        public SolutionComponentsRepository(IOrganizationService organizationService, LogService logger)
        {
            this.organizationService = organizationService;
            this.logger = logger;
        }

        public List<Entity> GetAllSolutionsComponentsOfAGivenSolution(Guid solutionId)
        {
            logger.LogInfo($"Retrieving solutions component from solution {solutionId}");
            var querySolutionComponent = new QueryExpression(nameof(solutioncomponent));
            querySolutionComponent.ColumnSet.AddColumns(solutioncomponent.objectid, solutioncomponent.componenttype, solutioncomponent.rootcomponentbehaviour);

            querySolutionComponent.Criteria.AddCondition(solutioncomponent.solutionid, ConditionOperator.Equal, solutionId);

            return organizationService.RetrieveMultiple(querySolutionComponent).Entities.ToList();
        }

        public List<Entity> GetSolutionComponentsByIds(List<Guid> objectId, int componenType)
        {
            logger.LogInfo($"Retrieving solutions components of type {componenType} from target environment");

            var querySolutionComponent = new QueryExpression(nameof(solutioncomponent));
            querySolutionComponent.NoLock = true;
            querySolutionComponent.Distinct = true;

            querySolutionComponent.ColumnSet.AddColumn(solutioncomponent.objectid);

            querySolutionComponent.Criteria.AddCondition(solutioncomponent.objectid, ConditionOperator.In, objectId.Cast<object>().ToArray());
            querySolutionComponent.Criteria.AddCondition(solutioncomponent.componenttype, ConditionOperator.Equal, componenType);

            return organizationService.RetrieveMultiple(querySolutionComponent).Entities.ToList();
        }
    }
}
