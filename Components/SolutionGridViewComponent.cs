﻿using Emmetienne.SolutionReplicator.Components.Model;
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
            this.solutionGridViewComponent.CellDoubleClick += OnRowDoubleClick;
            this.solutionGridViewComponent.Sorted += OnSort;
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
            solutionDataTable.Columns.Add(ComponentConstants.SolutionGridViewConstants.DisplayName, typeof(string));
            solutionDataTable.Columns.Add(ComponentConstants.SolutionGridViewConstants.UniqueName, typeof(string));
            solutionDataTable.Columns.Add(ComponentConstants.SolutionGridViewConstants.InstalledDate, typeof(DateTime));
            solutionDataTable.Columns.Add(ComponentConstants.SolutionGridViewConstants.Version, typeof(string));
            solutionDataTable.Columns.Add(ComponentConstants.SolutionGridViewConstants.Managed, typeof(bool));
            solutionDataTable.Columns.Add(ComponentConstants.SolutionGridViewConstants.SolutionId, typeof(Guid));

            foreach (var result in list)
            {
                solutionDataTable.Rows.Add(result.FriendlyName, result.UniqueName, result.CreatedOn, result.Version, result.IsManaged.ToString(), result.SolutionId);
            }

            solutionGridViewComponent.DataSource = solutionDataTable;
        }

        public override void OnCellSelection(object sender, EventArgs e)
        {
            var solutionId = GetSolutionIdFromDataTable(sender);

            EventBus.EventBusSingleton.Instance.retrieveSolutionComponents?.Invoke(solutionId);
            this.selectedSolutionId = solutionId;
        }

        private Guid GetSolutionIdFromDataTable(object sender)
        {
            var tmpDataGridView = (DataGridView)sender;
            var solutionId = RetrieveSolutionIdFromDataTable(this.solutionGridViewComponent.SelectedRows[0].Index);
            return solutionId;
        }

        private Guid RetrieveSolutionIdFromDataTable(int rowIndex)
        {
            var row = this.solutionGridViewComponent.Rows[rowIndex];
            var solutionId = (Guid)row.Cells[ComponentConstants.SolutionGridViewConstants.SolutionId]?.Value;
            var solutionName = (string)row.Cells[ComponentConstants.SolutionGridViewConstants.UniqueName]?.Value;

            EventBus.EventBusSingleton.Instance.emitSourceSolutionId?.Invoke(solutionId);
            EventBus.EventBusSingleton.Instance.emitSourceSolutionUniqueName?.Invoke(solutionName);

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

        public override void OnRowDoubleClick(object sender, EventArgs e)
        {
            var solutionId = GetSolutionIdFromDataTable(sender);

            EventBus.EventBusSingleton.Instance.emitSolutionIdToOpenBrowser?.Invoke(true, solutionId);
        }
    }
}
