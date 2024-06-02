﻿using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Repository;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using XrmToolBox.Extensibility;

namespace Emmetienne.SolutionReplicator.Services
{
    internal class SolutionRetrieverService : ServiceBase
    {
        private readonly LogService logService;
        private readonly PluginControlBase pluginControlBase;
        private SolutionRepository solutionRepository;
        public List<SolutionWrapper> Solutions { get; private set; } = new List<SolutionWrapper>();
        public List<SolutionWrapper> FilteredSolutions { get; private set; } = new List<SolutionWrapper>();

        public SolutionRetrieverService(LogService logService, PluginControlBase pluginBase)
        {
            this.logService = logService;
            this.pluginControlBase = pluginBase;

            this.solutionRepository = new SolutionRepository(pluginControlBase.Service, logService);

            EventBus.EventBusSingleton.Instance.changeSourceOrganizationService += ChangeMainConnection;
            EventBus.EventBusSingleton.Instance.filterSolutionComponent += FilterSolutions;
        }

        public void GetSolutions()
        {

            pluginControlBase.WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving solutions",
                Work = (worker, args) =>
                {
                    EventBus.EventBusSingleton.Instance.clearAllViews?.Invoke();
                    EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(true);

                    var results = solutionRepository.GetAllSolutionsInSourceEnvironment();
                    var wrappedResults = results.Select(x => SolutionWrapper.ToSolutionWrapper(x)).ToList();
                    args.Result = wrappedResults;

                    Solutions = wrappedResults;

                    logService.LogInfo($"Found {wrappedResults.Count} solutions");
                },
                PostWorkCallBack = (args) =>
                {
                    EventBus.EventBusSingleton.Instance.fillSolutionsView?.Invoke((List<SolutionWrapper>)args.Result);
                    EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(false);
                }
            });
        }

        public void FilterSolutions(string solutionFilter)
        {
            if (Solutions == null || Solutions.Count == 0)
                return;

            if (string.IsNullOrWhiteSpace(solutionFilter))
            {
                EventBus.EventBusSingleton.Instance.fillSolutionsView?.Invoke(Solutions);
                EventBus.EventBusSingleton.Instance.clearSolutionComponentView?.Invoke();
                return;
            }

            FilteredSolutions = Solutions.Where(x => x.UniqueName.IndexOf(solutionFilter, StringComparison.OrdinalIgnoreCase) > -1 || x.FriendlyName.IndexOf(solutionFilter, StringComparison.OrdinalIgnoreCase) > -1).ToList();
            EventBus.EventBusSingleton.Instance.fillSolutionsView?.Invoke(FilteredSolutions);
            EventBus.EventBusSingleton.Instance.clearSolutionComponentView?.Invoke();
        }

        public override void ChangeMainConnection(IOrganizationService service)
        {
            this.solutionRepository = new SolutionRepository(pluginControlBase.Service, logService);
        }

        public override void ChangeTargetConnection(IOrganizationService service)
        {
            throw new System.NotImplementedException();
        }
    }
}
