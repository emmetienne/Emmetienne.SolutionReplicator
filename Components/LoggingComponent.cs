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
            string[] row = new string[] { log.Timestamp.ToString(), log.Message, log.LogLevel.ToString() };

            this.loggingComponentDataGridView.ClearSelection();
            this.loggingComponentDataGridView.Rows.Add(row);
            this.loggingComponentDataGridView.FirstDisplayedScrollingRowIndex = this.loggingComponentDataGridView.Rows.Count - 1;

            this.loggingComponentDataGridView.Rows[this.loggingComponentDataGridView.Rows.Count - 1].DefaultCellStyle.ForeColor = log.Color;
        }

    }
}