using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class SolutionGridViewComponent : SolutionViewBase
    {
        private readonly DataGridView solutionGridViewComponent;
        private readonly LogService logService;
        private int selectedRowIndex = -1;
        private Guid? selectedSolutionId = null;

        public SolutionGridViewComponent(Component solutionGridViewComponent, LogService logService) : base()
        {
            this.solutionGridViewComponent = (DataGridView)solutionGridViewComponent;
            this.logService = logService;

            this.solutionGridViewComponent.CellClick += OnCellSelection;
            this.solutionGridViewComponent.Sorted += OnSort;

            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        public override void ClearGrid()
        {
            if (this.solutionGridViewComponent.InvokeRequired)
            {
                Action clearSafe = delegate { ClearGrid(); };
                this.solutionGridViewComponent.Invoke(clearSafe);
            }
            else
            {
                this.solutionGridViewComponent.DataBindings.Clear();
                this.solutionGridViewComponent.DataSource = null;
            }
        }

        public override void DisableComponent(bool isDisabled)
        {
            if (this.solutionGridViewComponent.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.solutionGridViewComponent.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.solutionGridViewComponent.Enabled = !isDisabled;
            }
        }

        public override void FillGrid(List<SolutionWrapper> list)
        {
            var solutionDataTable = new DataTable();
            solutionDataTable.Columns.Add("Display name", typeof(string));
            solutionDataTable.Columns.Add("Unique name", typeof(string));
            solutionDataTable.Columns.Add("Installed date", typeof(DateTime));
            solutionDataTable.Columns.Add("Version", typeof(string));
            solutionDataTable.Columns.Add("Managed", typeof(bool));
            solutionDataTable.Columns.Add("Solution Id", typeof(Guid));

            foreach (var result in list)
            {
                solutionDataTable.Rows.Add(result.FriendlyName, result.UniqueName, result.CreatedOn, result.Version, result.IsManaged.ToString(), result.SolutionId);
            }

            solutionGridViewComponent.DataSource = solutionDataTable;
        }

        public override void OnCellSelection(object sender, EventArgs e)
        {
            var tmpDataGridView = (DataGridView)sender;
            var solutionId = RetrieveSolutionIdFromDataTable(this.solutionGridViewComponent.SelectedRows[0].Index);

            EventBus.EventBusSingleton.Instance.retrieveSolutionComponents?.Invoke(solutionId);
            this.selectedSolutionId = solutionId;
        }

        private Guid RetrieveSolutionIdFromDataTable(int rowIndex)
        {
            var row = this.solutionGridViewComponent.Rows[rowIndex];
            var solutionId = (Guid)row.Cells["Solution Id"]?.Value;
            return solutionId;
        }

        public void OnSort(object sender, EventArgs e)
        {

            if (!selectedSolutionId.HasValue)
                return;

            
            foreach (DataGridViewRow row in this.solutionGridViewComponent.Rows)
            {
                var rowSolutionId = RetrieveSolutionIdFromDataTable(row.Index);

                if (rowSolutionId == selectedSolutionId)
                {
                    selectedRowIndex = row.Index;
                    break;
                }
            }

            this.solutionGridViewComponent.Rows[selectedRowIndex].Selected = true;
            this.solutionGridViewComponent.FirstDisplayedScrollingRowIndex = selectedRowIndex;
        }
    }
}
