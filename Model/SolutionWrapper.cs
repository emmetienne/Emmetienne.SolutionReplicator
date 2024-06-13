using Emmetienne.SolutionReplicator.Model.Entities;
using Microsoft.Xrm.Sdk;
using System;

namespace Emmetienne.SolutionReplicator.Model
{
    public class SolutionWrapper
    {
        public Guid SolutionId { get; set; }
        public string UniqueName { get; set; }
        public string FriendlyName { get; set; }
        public string Version { get; set; }
        public bool IsManaged { get; set; }
        public DateTime? CreatedOn { get; set; }

        public static SolutionWrapper ToSolutionWrapper(Entity retrievedRecord)
        {
            var tmpSolution = new SolutionWrapper();
            tmpSolution.SolutionId = retrievedRecord.Id;
            tmpSolution.UniqueName = retrievedRecord.GetAttributeValue<string>(solution.uniquename);
            tmpSolution.FriendlyName = retrievedRecord.GetAttributeValue<string>(solution.friendlyname);
            tmpSolution.Version = retrievedRecord.GetAttributeValue<string>(solution.version);
            tmpSolution.IsManaged = retrievedRecord.GetAttributeValue<bool>(solution.ismanaged);
            tmpSolution.CreatedOn = retrievedRecord.GetAttributeValue<DateTime?>(solution.createdon);
            return tmpSolution;
        }
    }
}
