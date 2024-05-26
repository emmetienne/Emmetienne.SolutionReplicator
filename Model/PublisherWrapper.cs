using Emmetienne.SolutionReplicator.Model.Entities;
using Microsoft.Xrm.Sdk;
using System;

namespace Emmetienne.SolutionReplicator.Model
{
    public class PublisherWrapper
    {
        public Guid PublisherId { get; set; }
        public string UniqueName { get; set; }
        public string FriendlyName { get; set; }
        public string CustomizationPrefix { get; set; }

        public static PublisherWrapper ToPublisherWrapper(Entity retrievedRecord)
        {
            var tmpSolution = new PublisherWrapper();
            tmpSolution.PublisherId = retrievedRecord.Id;
            tmpSolution.UniqueName = retrievedRecord.GetAttributeValue<string>(publisher.uniquename);
            tmpSolution.FriendlyName = retrievedRecord.GetAttributeValue<string>(publisher.friendlyname);
            tmpSolution.CustomizationPrefix = retrievedRecord.GetAttributeValue<string>(publisher.customizationprefix);
           
            return tmpSolution;
        }
    }
}
