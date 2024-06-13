using Emmetienne.SolutionReplicator.Model.Logging;

namespace Emmetienne.SolutionReplicator.Services
{
    public class LogService
    {
        public LogService()
        {

        }

        public void LogInfo(string message, string exception = null)
        {
            var tmpLog = new LogModel();
            tmpLog.Message = message;
            tmpLog.Color = System.Drawing.Color.Black;
            tmpLog.LogLevel = LogLevel.info;

            WriteLog(tmpLog);
        }

        public void LogWarning(string message, string exception = null)
        {
            var tmpLog = new LogModel();
            tmpLog.Message = message;
            tmpLog.Color = System.Drawing.Color.Goldenrod;
            tmpLog.LogLevel = LogLevel.warning;

            WriteLog(tmpLog);
        }

        public void LogDebug(string message, string exception = null)
        {
            var tmpLog = new LogModel();
            tmpLog.Message = message;
            tmpLog.Color = System.Drawing.Color.Blue;
            tmpLog.LogLevel = LogLevel.debug;

            WriteLog(tmpLog);
        }

        public void LogError(string message, string exception = null)
        {
            var tmpLog = new LogModel();
            tmpLog.Message = message;
            tmpLog.Color = System.Drawing.Color.Red;
            tmpLog.LogLevel = LogLevel.error;

            if (!string.IsNullOrWhiteSpace(exception))
                tmpLog.Exception = exception;

            WriteLog(tmpLog);
        }

        private void WriteLog(LogModel log)
        {
            EventBus.EventBusSingleton.Instance.writeLog?.Invoke(log);
        }
    }
}
