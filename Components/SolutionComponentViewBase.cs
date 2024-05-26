using Emmetienne.SolutionReplicator.Model;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Components
{
    public abstract class SolutionComponentViewBase : IGridViewComponent, ISolutionComponentGridViewComponent
    {
        protected List<SolutionComponentWrapper> solutionComponents;
        public List<SolutionComponentWrapper> SolutionComponents { get => solutionComponents; }
        public abstract void ClearGrid();
        public abstract void DisableComponent(bool isDisabled);
        public abstract void FillGrid(List<SolutionComponentWrapper> list);
    }
}
