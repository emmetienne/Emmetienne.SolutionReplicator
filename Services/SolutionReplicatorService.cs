using Emmetienne.SolutionReplicator.ComponentSearchServiceStrategy.Strategy;
using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Repository;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using XrmToolBox.Extensibility;

namespace Emmetienne.SolutionReplicator.Services
{
    internal class SolutionReplicatorService
    {
        private readonly LogService logService;
        private readonly IOrganizationService sourceEnnvironmentService;
        private readonly IOrganizationService targetEnvironmentService;
        private readonly PluginControlBase pluginControlBase;
        private readonly SolutionRepository targetSolutionRepository;


        public SolutionReplicatorService(LogService logService, IOrganizationService sourceEnvironmentService, IOrganizationService targetEnvironmentService, PluginControlBase pluginControlBase)
        {
            this.logService = logService;
            this.sourceEnnvironmentService = sourceEnvironmentService;
            this.targetEnvironmentService = targetEnvironmentService;
            this.pluginControlBase = pluginControlBase;

            this.targetSolutionRepository = new SolutionRepository(targetEnvironmentService, logService);
        }

        public void ReplicateSolution(List<SolutionComponentWrapper> solutionComponents, TargetSolutionSettings targetSolutionSettings)
        {
            pluginControlBase.WorkAsync(new WorkAsyncInfo
            {
                Message = "Replicating components on target environment",
                Work = (worker, args) =>
                {
                    EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(true);

                    var foundAndNotFoundComponents = GetComponentsToAdd(solutionComponents);

                    EventBus.EventBusSingleton.Instance.setSolutionComponentStatus?.Invoke(foundAndNotFoundComponents);

                    worker.ReportProgress(0, $"Creating solution on target environment");

                    var createdSolutionData = targetSolutionRepository.CreateSolution(targetSolutionSettings);

                    EventBus.EventBusSingleton.Instance.emitTargetSolutionUniqueName?.Invoke(createdSolutionData.UniqueName);
                    EventBus.EventBusSingleton.Instance.emitTargetSolutionId?.Invoke(createdSolutionData.SolutionId);

                    AddComponentToSolution(foundAndNotFoundComponents, createdSolutionData, worker);

                    EventBus.EventBusSingleton.Instance.setSolutionComponentStatus?.Invoke(foundAndNotFoundComponents);

                    
                    if (foundAndNotFoundComponents.FoundComponents.Count(x=>!x.ReplicationStatus.Replicated) > 0)
                    {
                        logService.LogWarning($"The solution was replicated in the target environment with errors. See the solution component pane for more information. Components that were not replicated will be highlighted.");
                        return;
                    }

                    logService.LogInfo($"Solution replicated on the target environment");
                },
                ProgressChanged = (args) =>
                {
                    pluginControlBase.SetWorkingMessage(args.UserState.ToString());
                },
                PostWorkCallBack = (args) =>
                {
                    EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(false);
                }
            });
        }

        private FoundAndNotFoundComponents GetComponentsToAdd(List<SolutionComponentWrapper> notFoundComponents)
        {
            pluginControlBase.SetWorkingMessage($"Searching components on the target environment");

            var notFoundSolutionComponentsGroupedByComponentType = notFoundComponents.GroupBy(x => x.ComponentType).OrderBy(x => x.Key);

            var foundAndNotFoundComponents = new FoundAndNotFoundComponents();

            foreach (var group in notFoundSolutionComponentsGroupedByComponentType)
            {
                var messageToLog = $"Searching components of type {ComponentTypeCache.Instance.GetComponentTypeNameFromComponentType(group.Key)} on the target environment";

                pluginControlBase.SetWorkingMessage(messageToLog);
                logService.LogDebug(messageToLog);

                var componentTypeSearchStrategy = ComponentSearchStrategyFactory.GetComponentSearchStrategy(group.Key);

                foundAndNotFoundComponents.AddComponentsToFoundAndNotFoundList(componentTypeSearchStrategy.Handle(group, sourceEnnvironmentService, targetEnvironmentService, logService));
            }

            return foundAndNotFoundComponents;
        }

        private void AddComponentToSolution(FoundAndNotFoundComponents foundAndNotFoundComponents, SolutionWrapper createdSolutionData, BackgroundWorker worker)
        {
            var componentCounter = 1;
            foreach (var component in foundAndNotFoundComponents.FoundComponents.OrderBy(x => x.ComponentType))
            {
                worker.ReportProgress(0, $"Adding component to target solution {Environment.NewLine} {componentCounter++}/{foundAndNotFoundComponents.FoundComponents.Count}");

                ReplicationStatus addToSolutionStatusResult = null;

                if (component.TargetEnvironmentObjectId.HasValue)
                    targetSolutionRepository.AddComponentToSolution(component.TargetEnvironmentObjectId.Value, component.ComponentType, createdSolutionData.UniqueName, component.RootComponentBehaviour, out addToSolutionStatusResult);
                else
                    targetSolutionRepository.AddComponentToSolution(component.ObjectId, component.ComponentType, createdSolutionData.UniqueName, component.RootComponentBehaviour, out addToSolutionStatusResult);

                component.ReplicationStatus = addToSolutionStatusResult;
            }
        }
    }
}
