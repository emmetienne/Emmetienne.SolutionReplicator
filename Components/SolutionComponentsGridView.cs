using Emmetienne.SolutionReplicator.Components.Model;
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
            solutionComponentsDataTable.Columns.Add(ComponentConstants.SolutionComponentView.ComponentType, typeof(string));
            solutionComponentsDataTable.Columns.Add(ComponentConstants.SolutionComponentView.ComponentTypeName, typeof(string));
            solutionComponentsDataTable.Columns.Add(ComponentConstants.SolutionComponentView.ObjectId, typeof(Guid));
            solutionComponentsDataTable.Columns.Add(ComponentConstants.SolutionComponentView.ComponentSearchStatus, typeof(string));
            solutionComponentsDataTable.Columns.Add(ComponentConstants.SolutionComponentView.Replicated, typeof(bool));
            solutionComponentsDataTable.Columns.Add(ComponentConstants.SolutionComponentView.ErrorMessage, typeof(string));

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
            solutionComponentGridViewComponent.Columns[ComponentConstants.SolutionComponentView.ComponentType].SortMode = DataGridViewColumnSortMode.NotSortable;
            solutionComponentGridViewComponent.Columns[ComponentConstants.SolutionComponentView.ComponentTypeName].SortMode = DataGridViewColumnSortMode.NotSortable;
            solutionComponentGridViewComponent.Columns[ComponentConstants.SolutionComponentView.ObjectId].SortMode = DataGridViewColumnSortMode.NotSortable;
            solutionComponentGridViewComponent.Columns[ComponentConstants.SolutionComponentView.ComponentSearchStatus].SortMode = DataGridViewColumnSortMode.NotSortable;
            solutionComponentGridViewComponent.Columns[ComponentConstants.SolutionComponentView.Replicated].SortMode = DataGridViewColumnSortMode.NotSortable;
            solutionComponentGridViewComponent.Columns[ComponentConstants.SolutionComponentView.ErrorMessage].SortMode = DataGridViewColumnSortMode.NotSortable;
        }

        public override void SetComponentStateInView(FoundAndNotFoundComponents list)
        {
            if (!currentSelectedSolutionId.HasValue)
                return;

            var currentRow = 0;
            foreach (DataGridViewRow row in this.solutionComponentGridViewComponent.Rows)
            {
                if (row.IsNewRow)
                    continue;

                var componentObjectId = (Guid?)row.Cells[ComponentConstants.SolutionComponentView.ObjectId]?.Value;

                var isFoundComponentList = list.FoundComponents.Where(x => x.ObjectId == componentObjectId).ToList();
                var isNotFoundComponent = list.NotFoundComponents.FirstOrDefault(x => x.ObjectId == componentObjectId);

                if (isFoundComponentList.Count != 0)
                {
                    row.Cells[ComponentConstants.SolutionComponentView.ComponentSearchStatus].Value = isFoundComponentList[0].ComponentSearchResult.Message;
                    ColorRow(currentRow, isFoundComponentList[0].ComponentSearchResult.ForeGroundColor);

                    if (isFoundComponentList.Count(x => x.ReplicationStatus == null) == isFoundComponentList.Count)
                    {
                        currentRow++;
                        continue;
                    }

                    var isComponentReplicated = isFoundComponentList.Count(x => x.ReplicationStatus.Replicated) == isFoundComponentList.Count;

                    if (!isComponentReplicated)
                        ColorRow(currentRow, Color.Black, true);

                    row.Cells[ComponentConstants.SolutionComponentView.Replicated].Value = isComponentReplicated;
                    row.Cells[ComponentConstants.SolutionComponentView.ErrorMessage].Value = string.Join("|", isFoundComponentList.Where(x => !string.IsNullOrWhiteSpace(x.ReplicationStatus.ErrorMessage)).Select(y => y.ReplicationStatus.ErrorMessage).ToList());

                    currentRow++;
                    continue;
                }

                if (isNotFoundComponent != null)
                {
                    row.Cells[ComponentConstants.SolutionComponentView.ComponentSearchStatus].Value = isNotFoundComponent.ComponentSearchResult.Message;
                    ColorRow(currentRow, isNotFoundComponent.ComponentSearchResult.ForeGroundColor);
                }

                currentRow++;
            }
        }

        private void ColorRow(int currentRow, Color color, bool background = false)
        {
            if (background)
                this.solutionComponentGridViewComponent.Rows[currentRow].DefaultCellStyle.BackColor = color;
            else
                this.solutionComponentGridViewComponent.Rows[currentRow].DefaultCellStyle.ForeColor = color;
        }
    }
}