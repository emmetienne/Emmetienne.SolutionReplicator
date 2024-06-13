using Microsoft.Xrm.Sdk;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Services
{
    internal static class MetadataServiceSingleton 
    {
        private static Dictionary<int, string> solutionComponentTypeDictionary;
        public static Dictionary<int, string> SolutionComponentTypeDictionary { get => solutionComponentTypeDictionary; }

        public static Dictionary<int, string> GetComponentTypeDictionary(IOrganizationService organizationService, LogService logService)
        {
            if (solutionComponentTypeDictionary != null && solutionComponentTypeDictionary.Count == 0)
                return solutionComponentTypeDictionary;
            else
                solutionComponentTypeDictionary = new Dictionary<int, string>();

            var componentTypeOptionSetService = new ComponentTypeOptionSetService(organizationService, logService);

            solutionComponentTypeDictionary = componentTypeOptionSetService.GetComponentTypeDictionary();

            return solutionComponentTypeDictionary;
        }
    }
}