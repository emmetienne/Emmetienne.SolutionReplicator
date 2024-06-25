using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class SolutionComponentsGridView : SolutionComponentViewBase
    {
        private readonly DataGridView solutionComponentGridViewComponent;
        private readonly LogService logService;


        public SolutionComponentsGridView(Component solutionGridViewComponent, LogService logService) : base()
        {
            this.solutionComponentGridViewComponent = (DataGridView)solutionGridViewComponent;
            this.logService = logService;
        }

        public override void ClearGrid()
        {
            if (this.solutionComponentGridViewComponent.InvokeRequired)
            {
                Action clearSafe = delegate { ClearGrid(); };
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
            solutionComponentsDataTable.Columns.Add("Replication status", typeof(string));

            foreach (var result in list)
            {
                solutionComponentsDataTable.Rows.Add(result.ComponentType, result.ComponentTypeName, result.ObjectId, result.ComponentSearchResult.Message);
            }

            this.solutionComponentGridViewComponent.DataSource = solutionComponentsDataTable;
            this.solutionComponents = list;

            this.solutionComponentGridViewComponent.ClearSelection();
            SetColumnsAsNonSortable();
        }

        private void SetColumnsAsNonSortable()
        {
            solutionComponentGridViewComponent.Columns["Component type"].SortMode = DataGridViewColumnSortMode.NotSortable;
            solutionComponentGridViewComponent.Columns["Component type name"].SortMode = DataGridViewColumnSortMode.NotSortable;
            solutionComponentGridViewComponent.Columns["Object id"].SortMode = DataGridViewColumnSortMode.NotSortable;
            solutionComponentGridViewComponent.Columns["Replication status"].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public override void ColorComponentsInGrid(FoundAndNotFoundComponents list)
        {
            if (!currentSelectedSolutionId.HasValue)
                return;

            var currentRow = 0;
            foreach (DataGridViewRow row in this.solutionComponentGridViewComponent.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var componentObjectId = (Guid?) row.Cells["Object id"]?.Value;

                var isFoundComponent = list.FoundComponents.FirstOrDefault(x => x.ObjectId == componentObjectId);
                var isNotFoundComponent = list.NotFoundComponents.FirstOrDefault(x=>x.ObjectId == componentObjectId);

                if (isFoundComponent != null)
                {
                    row.Cells["Replication status"].Value = isFoundComponent.ComponentSearchResult.Message;
                    ColorRow(currentRow, isFoundComponent.ComponentSearchResult.ForeGroundColor);
                    
                    currentRow++;
                    continue;
                }

                if (isNotFoundComponent != null)
                {
                    row.Cells["Replication status"].Value = isNotFoundComponent.ComponentSearchResult.Message;
                    ColorRow(currentRow, isNotFoundComponent.ComponentSearchResult.ForeGroundColor);
                }

                currentRow++;
            }
        }

        private void ColorRow(int currentRow, Color color)
        {
            this.solutionComponentGridViewComponent.Rows[currentRow].DefaultCellStyle.ForeColor = color;
        }
    }
}