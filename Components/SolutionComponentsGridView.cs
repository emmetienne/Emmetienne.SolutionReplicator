using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class SolutionComponentsGridView : SolutionComponentViewBase
    {
        private readonly DataGridView solutionComponentGridViewComponent;
        private readonly LogService logService;


        public SolutionComponentsGridView(Component solutionGridViewComponent, LogService logService)
        {
            this.solutionComponentGridViewComponent = (DataGridView)solutionGridViewComponent;
            this.logService = logService;

            EventBus.EventBusSingleton.Instance.clearAllViews += ClearGrid;
            EventBus.EventBusSingleton.Instance.clearSolutionComponentView += ClearGrid;
            EventBus.EventBusSingleton.Instance.fillSolutionComponentView += FillGrid;
            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        public override void ClearGrid()
        {
            if (this.solutionComponentGridViewComponent.InvokeRequired)
            {
                Action clearSafe =  delegate { ClearGrid(); };
                this.solutionComponentGridViewComponent.Invoke(clearSafe);
            }
            else
            {
                this.solutionComponentGridViewComponent.DataBindings.Clear();
                this.solutionComponentGridViewComponent.DataSource = null;
            }
        }

        public override void DisableComponent(bool isDisabled)
        {
            if (this.solutionComponentGridViewComponent.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.solutionComponentGridViewComponent.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.solutionComponentGridViewComponent.Enabled = !isDisabled;
            }
        }

        public override void FillGrid(List<SolutionComponentWrapper> list)
        {
            var solutionComponentsDataTable = new DataTable();
            solutionComponentsDataTable.Columns.Add("Component type", typeof(string));
            solutionComponentsDataTable.Columns.Add("Component type name", typeof(string));
            solutionComponentsDataTable.Columns.Add("Object id", typeof(Guid));

            foreach (var result in list)
            {
                solutionComponentsDataTable.Rows.Add(result.ComponentType, result.ComponentTypeName, result.ObjectId);
            }

            this.solutionComponentGridViewComponent.DataSource = solutionComponentsDataTable;
            this.solutionComponents = list;

            this.solutionComponentGridViewComponent.ClearSelection();
        }
    }
}
