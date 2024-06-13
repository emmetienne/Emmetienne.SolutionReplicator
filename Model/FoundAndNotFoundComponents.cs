using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Model
{
    public class FoundAndNotFoundComponents
    {
        public List<SolutionComponentWrapper> FoundComponents { get; set; }
        public List<SolutionComponentWrapper> NotFoundComponents { get; set; }

        public FoundAndNotFoundComponents()
        {
            FoundComponents = new List<SolutionComponentWrapper>();
            NotFoundComponents = new List<SolutionComponentWrapper>();
        }

        public void AddComponentsToFoundAndNotFoundList(FoundAndNotFoundComponents goodAndBadComponents)
        {
            this.FoundComponents.AddRange(goodAndBadComponents.FoundComponents);
            this.NotFoundComponents.AddRange(goodAndBadComponents.NotFoundComponents);
        }
    }
}