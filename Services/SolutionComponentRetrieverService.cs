using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Repository;
using Emmetienne.SolutionReplicator.Services.ComponentNameRetrieveStrategy;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using XrmToolBox.Extensibility;

namespace Emmetienne.SolutionReplicator.Services
{
    internal class SolutionComponentRetrieverService : ServiceBase
    {
        private readonly LogService logService;
        private readonly IOrganizationService organizationService;
        private readonly PluginControlBase pluginControlBase;
        private SolutionComponentsRepository solutionComponentRepository;
        private Dictionary<int, string> componentTypeDictionary;
        private bool retrieveComponentsNames;

        public SolutionComponentRetrieverService(LogService logService, IOrganizationService organizationService, PluginControlBase pluginControlBase)
        {
            this.logService = logService;
            this.organizationService = organizationService;
            this.pluginControlBase = pluginControlBase;

            this.solutionComponentRepository = new SolutionComponentsRepository(organizationService, logService);

            EventBus.EventBusSingleton.Instance.retrieveSolutionComponents += GetSolutionComponents;
            EventBus.EventBusSingleton.Instance.retrieveComponentsNames += SetRetrieveComponentsNamesBool;
            EventBus.EventBusSingleton.Instance.changeSourceOrganizationService += ChangeMainConnection;
        }

        public override void ChangeMainConnection(IOrganizationService service)
        {
            this.solutionComponentRepository = new SolutionComponentsRepository(service, logService);
        }

        public void GetSolutionComponents(Guid solutionId)
        {
            pluginControlBase.WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving solution components",
                Work = (worker, args) =>
                {
                    EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(true);

                    var results = solutionComponentRepository.GetAllSolutionsComponentsOfAGivenSolution(solutionId);

                    if (componentTypeDictionary == null)
                        componentTypeDictionary = MetadataServiceSingleton.GetComponentTypeDictionary(organizationService, logService);

                    var wrappedResults = results.Select(x => SolutionComponentWrapper.ToSolutionComponentWrapper(x, componentTypeDictionary)).OrderBy(x => x.ComponentType).ToList();

                    if (retrieveComponentsNames)
                        RetrieveComponentsNames(wrappedResults);

                    args.Result = wrappedResults;

                    logService.LogInfo($"Found {wrappedResults.Count} component in solution");

                },
                PostWorkCallBack = (args) =>
                {
                    EventBus.EventBusSingleton.Instance.clearSolutionComponentView?.Invoke();
                    EventBus.EventBusSingleton.Instance.fillSolutionComponentView?.Invoke((List<SolutionComponentWrapper>)args.Result);
                    EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(false);
                }
            });
        }

        private void SetRetrieveComponentsNamesBool(bool rerieveComponentsNames)
        {
            this.retrieveComponentsNames = rerieveComponentsNames;
        }

        private void RetrieveComponentsNames(List<SolutionComponentWrapper> wrappedResults)
        {
            foreach (var singleComponent in wrappedResults)
            {
                var componentRetrieveStrategy = ComponentNameRetrieveStrategyFactory.GetComponentNameRetrieveStrategy(singleComponent.ComponentType);

                if (componentRetrieveStrategy == null)
                    continue;

               componentRetrieveStrategy.Handle(singleComponent, organizationService, logService);
            }
        }
    }
}