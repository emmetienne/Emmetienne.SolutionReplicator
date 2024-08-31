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

        public void AddComponentToSolution(Guid objectId, int componenType, string solutionUniqueName, int? rootComponentBehaviour, out ReplicationStatus addToSolutionStatus)
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

            logger.LogDebug($"Adding component {objectId} to solution {solutionUniqueName}");

            try
            {
                organizationService.Execute(addSolutionComponentRequest);
            }
            catch (Exception ex)
            {
                logger.LogError($"Error on adding component with id {objectId} of type {componenType}", ex.Message);
                addToSolutionStatus = ReplicationStatus.SetReplicationStatus(false, ex.Message);
                return;
            }

            addToSolutionStatus = ReplicationStatus.SetReplicationStatus(true);
        }

        public SolutionWrapper CreateSolution(TargetSolutionSettings targetSolutionSettings)
        {
            var targetSolution = new Entity(nameof(solution));
            targetSolution[solution.uniquename] = $"{targetSolutionSettings.SolutionName}_{Guid.NewGuid().ToString().Substring(0, 7)}_{DateTime.Now.ToString("yyyyMMdd")}";
            targetSolution[solution.friendlyname] = targetSolutionSettings.SolutionName;
            targetSolution[solution.version] = targetSolutionSettings.Version;
            targetSolution[solution.publisherid] = new EntityReference(nameof(publisher), targetSolutionSettings.Publisher.Value);

            targetSolution.Id = organizationService.Create(targetSolution);

            logger.LogDebug($"Solution {targetSolution[solution.uniquename]} created with id {targetSolution.Id} on the target environment");

            return SolutionWrapper.ToSolutionWrapper(targetSolution);
        }

        public byte[] ExportSoluton(string solutionUniqueName)
        {
            ExportSolutionRequest exportSolutionRequest = new ExportSolutionRequest
            {
                SolutionName = solutionUniqueName,
                Managed = false
            };

            var exportSolutionResponse = (ExportSolutionResponse)organizationService.Execute(exportSolutionRequest);

            return exportSolutionResponse.ExportSolutionFile;
        }
    }
}
