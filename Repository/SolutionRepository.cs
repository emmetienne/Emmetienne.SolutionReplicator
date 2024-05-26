using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Model.Entities;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Emmetienne.SolutionReplicator.Repository
{
    internal class SolutionRepository
    {
        private IOrganizationService organizationService;
        private LogService logger;

        public SolutionRepository(IOrganizationService organizationService, LogService logger)
        {
            this.organizationService = organizationService;
            this.logger = logger;
        }

        public List<Entity> GetAllSolutionsInSourceEnvironment()
        {
            logger.LogInfo("Retrieving solutions on source environment");

            var querySolution = new QueryExpression(nameof(solution));
            querySolution.ColumnSet.AddColumns(solution.uniquename, solution.friendlyname, solution.version, solution.ismanaged, solution.createdon);
            querySolution.Criteria.AddCondition(solution.isvisible, ConditionOperator.Equal, true);
            querySolution.Criteria.AddCondition(solution.uniquename, ConditionOperator.NotEqual, "default");

            return organizationService.RetrieveMultiple(querySolution).Entities.ToList();
        }

        public void AddComponentToSolution(Guid objectId, int componenType, string solutionUniqueName, int? rootComponentBehaviour)
        {
            var addSolutionComponentRequest = new AddSolutionComponentRequest();

            addSolutionComponentRequest.ComponentType = componenType;
            addSolutionComponentRequest.ComponentId = objectId;
            addSolutionComponentRequest.SolutionUniqueName = solutionUniqueName;
            addSolutionComponentRequest.AddRequiredComponents = false;

            if (componenType == 1)
                addSolutionComponentRequest.DoNotIncludeSubcomponents = true;

            if (componenType == 20)
                addSolutionComponentRequest.DoNotIncludeSubcomponents = false;

            organizationService.Execute(addSolutionComponentRequest);
        }

        public void RemoveComponentToSolution(Guid objectId, int componenType, string solutionUniqueName)
        {
            var removeSolutionComponentRequest = new RemoveSolutionComponentRequest();

            removeSolutionComponentRequest.ComponentType = componenType;
            removeSolutionComponentRequest.ComponentId = objectId;
            removeSolutionComponentRequest.SolutionUniqueName = solutionUniqueName;

            var response = (RemoveSolutionComponentResponse)organizationService.Execute(removeSolutionComponentRequest);
        }

        public SolutionWrapper CreateSolution(TargetSolutionSettings targetSolutionSettings)
        {
            var targetSolution = new Entity(nameof(solution));
            targetSolution[solution.uniquename] = $"{targetSolutionSettings.SolutionName}_{Guid.NewGuid().ToString().Substring(0, 7)}_{DateTime.Now.ToString("yyyyMMdd")}";
            targetSolution[solution.friendlyname] = targetSolutionSettings.SolutionName;
            targetSolution[solution.version] = targetSolutionSettings.Version;
            targetSolution[solution.publisherid] = new EntityReference(nameof(publisher), targetSolutionSettings.Publisher.Value);

            var createdSolutionId = organizationService.Create(targetSolution);

            targetSolution.Id = createdSolutionId;

            return SolutionWrapper.ToSolutionWrapper(targetSolution);
        }
    }
}
