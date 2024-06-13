using Emmetienne.SolutionReplicator.Model.Logging;

namespace Emmetienne.SolutionReplicator.Components
{
    public interface ILoggingComponent
    {
        void WriteLog(LogModel log);
        void ClearLogs();
    }
}
