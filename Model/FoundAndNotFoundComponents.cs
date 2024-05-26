﻿using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Model
{
    internal class FoundAndNotFoundComponents
    {
        public List<SolutionComponentWrapper> FoundComponents { get; set; }
        public List<SolutionComponentWrapper> NotFoundComponents { get; set; }

        public FoundAndNotFoundComponents()
        {
            FoundComponents = new List<SolutionComponentWrapper>();
            NotFoundComponents = new List<SolutionComponentWrapper>();
        }

        public void AddGoodAndBadcomponents(FoundAndNotFoundComponents goodAndBadComponents)
        {
            this.FoundComponents.AddRange(goodAndBadComponents.FoundComponents);
            this.NotFoundComponents.AddRange(goodAndBadComponents.NotFoundComponents);
        }
    }
}