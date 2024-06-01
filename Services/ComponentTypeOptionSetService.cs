using Emmetienne.SolutionReplicator.Repository;
using Microsoft.Xrm.Sdk;
using System.Collections.Generic;
using System.Linq;

namespace Emmetienne.SolutionReplicator.Services
{
    internal class ComponentTypeOptionSetService
    {
        private readonly IOrganizationService organizationService;
        private readonly LogService logService;
        private readonly SolutionComponentTypesRepository solutionComponentTypesRepository;

        private Dictionary<int, string> componentTypeNameDictionary;

        public ComponentTypeOptionSetService(IOrganizationService organizationService, LogService logService)
        {
            this.organizationService = organizationService;
            this.logService = logService;
            this.solutionComponentTypesRepository = new SolutionComponentTypesRepository(this.organizationService, this.logService);
        }

        public Dictionary<int, string> GetComponentTypeDictionary()
        {
            if (componentTypeNameDictionary == null)
                componentTypeNameDictionary = new Dictionary<int, string>();

            if (componentTypeNameDictionary.Count > 0)
                return componentTypeNameDictionary;

            var solutionComponentTypeOptionSet = solutionComponentTypesRepository.GetComponentTypesFromEnvironment();

            if (solutionComponentTypeOptionSet == null)
                return componentTypeNameDictionary;

            foreach (var option in solutionComponentTypeOptionSet.Options)
            {
                var tmpComponentTypeString = option.Label?.LocalizedLabels?.FirstOrDefault().Label;

                if (string.IsNullOrWhiteSpace(tmpComponentTypeString))
                    tmpComponentTypeString =  $"{option.Value} N/A";

                componentTypeNameDictionary.Add(option.Value.Value, tmpComponentTypeString);
            }

            return componentTypeNameDictionary;
        }
    }
}
