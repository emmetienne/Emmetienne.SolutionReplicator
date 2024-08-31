using Emmetienne.SolutionReplicator.Model;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Components
{
    public interface ISolutionComponentGridViewComponent
    {
        void FillGrid(List<SolutionComponentWrapper> list);
        void SetComponentStateInView(FoundAndNotFoundComponents list);
    }
}
