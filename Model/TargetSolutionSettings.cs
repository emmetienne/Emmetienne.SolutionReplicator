using System;

namespace Emmetienne.SolutionReplicator.Model
{
    public class TargetSolutionSettings
    {
        public string SolutionName { get; set; }
        public Guid? Publisher { get; set; }
        public bool PruneAutoAddedComponents { get; set; }
        public string Version { get; set; }

        public TargetSolutionSettings(string solutionName, Guid? publisher, bool pruneAutoAddedComponents, string version = "1.0.0.0")
        {
            this.SolutionName = solutionName;
            this.Publisher = publisher;
            this.PruneAutoAddedComponents = pruneAutoAddedComponents;
            this.Version = version;

        }
    }
}
