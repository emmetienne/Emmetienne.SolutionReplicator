using System;

namespace Emmetienne.SolutionReplicator.Model
{
    public class TargetSolutionSettings
    {
        public string SolutionName { get; set; }
        public Guid? Publisher { get; set; }
        public string Version { get; set; }

        public TargetSolutionSettings(string solutionName, Guid? publisher, string version = "1.0.0.0")
        {
            this.SolutionName = solutionName;
            this.Publisher = publisher;
            this.Version = version;
        }
    }
}
