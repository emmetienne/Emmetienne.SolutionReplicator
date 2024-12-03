using Emmetienne.SolutionReplicator.Model.Logging;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class LoggingComponent : ILoggingComponent
    {
        private readonly DataGridView loggingComponentDataGridView;

        public LoggingComponent(Component logComponent)
        {
            this.loggingComponentDataGridView = (DataGridView)logComponent;

            EventBus.EventBusSingleton.Instance.writeLog += WriteLog;
        }

        public void ClearLogs()
        {
            throw new System.NotImplementedException();
        }

        public void WriteLog(LogModel log)
        {

            if (this.loggingComponentDataGridView.InvokeRequired)
            {
                Action writeLogSafe = delegate { WriteInternal(log); };

                this.loggingComponentDataGridView.Invoke(writeLogSafe);
            }
            else
            {
                WriteInternal(log);
            }
        }

        private void WriteInternal(LogModel log)
        {
            if (this.loggingComponentDataGridView.IsDisposed)
                return;

            if (this.loggingComponentDataGridView.Columns == null || this.loggingComponentDataGridView.Columns.Count == 0)
                InitializeColumns();

            string[] row = new string[] { log.Timestamp.ToString(), log.Message, !string.IsNullOrWhiteSpace(log.Exception) ? log.Exception : string.Empty, log.LogLevel.ToString() };

            this.loggingComponentDataGridView.ClearSelection();

            this.loggingComponentDataGridView.Rows.Add(row);
            this.loggingComponentDataGridView.FirstDisplayedScrollingRowIndex = this.loggingComponentDataGridView.Rows.Count - 1;

            this.loggingComponentDataGridView.Rows[this.loggingComponentDataGridView.Rows.Count - 1].DefaultCellStyle.ForeColor = log.Color;
        }

        private void InitializeColumns()
        {
            var timeStampColumn = new DataGridViewTextBoxColumn();
            timeStampColumn.Name = "Timestamp";
            timeStampColumn.HeaderText = "Timestamp";
            this.loggingComponentDataGridView.Columns.Add(timeStampColumn);

            var messageColumn = new DataGridViewTextBoxColumn();
            messageColumn.Name = "Message";
            messageColumn.HeaderText = "Message";
            this.loggingComponentDataGridView.Columns.Add(messageColumn);

            var exceptionColumn = new DataGridViewTextBoxColumn();
            exceptionColumn.Name = "Exception";
            exceptionColumn.HeaderText = "Exception";
            this.loggingComponentDataGridView.Columns.Add(exceptionColumn);

            var severityColumn = new DataGridViewTextBoxColumn();
            severityColumn.Name = "Severity";
            severityColumn.HeaderText = "Severity";
            this.loggingComponentDataGridView.Columns.Add(severityColumn);
        }
    }
}