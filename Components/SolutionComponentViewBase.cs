using Emmetienne.SolutionReplicator.Model;
using System;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Components
{
    public abstract class SolutionComponentViewBase : IGridViewComponent, ISolutionComponentGridViewComponent
    {
        protected List<SolutionComponentWrapper> solutionComponents;
        public List<SolutionComponentWrapper> SolutionComponents { get => solutionComponents; }
        protected Guid? currentSelectedSolutionId;
        public abstract void ClearGrid();
        public abstract void DisableComponent(bool isDisabled);
        public abstract void FillGrid(List<SolutionComponentWrapper> list);
        public abstract void ColorComponentsInGrid(FoundAndNotFoundComponents list);

        protected SolutionComponentViewBase()
        {
            EventBus.EventBusSingleton.Instance.clearAllViews += ClearGrid;
            EventBus.EventBusSingleton.Instance.clearSolutionComponentView += ClearGrid;
            EventBus.EventBusSingleton.Instance.fillSolutionComponentView += FillGrid;
            EventBus.EventBusSingleton.Instance.colorSolutionComponentInView += ColorComponentsInGrid;
            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
            EventBus.EventBusSingleton.Instance.emitSourceSolutionId += setCurrentSelectedSolutionId;
        }

        public virtual void setCurrentSelectedSolutionId(Guid? solutionId)
        {
            currentSelectedSolutionId = solutionId;
        }
    }
}
