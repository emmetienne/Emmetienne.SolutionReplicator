using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Repository;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System.Linq;
using XrmToolBox.Extensibility;

namespace Emmetienne.SolutionReplicator.Services
{
    internal class PublisherRetrieverService
    {
        private readonly LogService logService;
        private readonly PluginControlBase pluginControlBase;
        private readonly PublisherRepository publisherRepository;

        public PublisherRetrieverService(LogService logService, IOrganizationService organizationService, PluginControlBase pluginBase)
        {
            this.logService = logService;
            this.pluginControlBase = pluginBase;

            this.publisherRepository = new PublisherRepository(organizationService, logService);
        }

        public void GetPublishers()
        {
            pluginControlBase.WorkAsync(new WorkAsyncInfo
            {
                Message = "Retrieving publishers on the target environment",
                Work = (worker, args) =>
                {
                    var results = publisherRepository.GetEnvironmentPublishers();
                    var wrappedResults = results.Select(x => PublisherWrapper.ToPublisherWrapper(x)).ToList();
                    args.Result = wrappedResults;

                    logService.LogInfo($"Found {wrappedResults.Count} publisher on the environment");
                },
                PostWorkCallBack = (args) =>
                {
                    EventBus.EventBusSingleton.Instance.fillPublisherComboBox?.Invoke((List<PublisherWrapper>)args.Result);
                }
            });
        }
    }
}
