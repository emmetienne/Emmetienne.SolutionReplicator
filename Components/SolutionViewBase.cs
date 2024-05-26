using Emmetienne.SolutionReplicator.Model;
using System;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Components
{
    public abstract class SolutionViewBase : IGridViewComponent, ISolutionGridViewComponent
    {
        public abstract void ClearGrid();
        public abstract void FillGrid(List<SolutionWrapper> list);
        public abstract void OnCellSelection(object sender, EventArgs e);
        public abstract void DisableComponent(bool isDisabled);

        protected SolutionViewBase()
        {
            EventBus.EventBusSingleton.Instance.clearAllViews += ClearGrid;
            EventBus.EventBusSingleton.Instance.clearSolutionView += ClearGrid;
            EventBus.EventBusSingleton.Instance.fillSolutionsView += FillGrid;
        }
    }
}