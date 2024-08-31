namespace Emmetienne.SolutionReplicator.Model
{
    public class ReplicationStatus
    {
        public bool Replicated { get; set; }
        public string ErrorMessage { get; set; }

        public static ReplicationStatus SetReplicationStatus(bool addedToSolution, string errorMessage = "")
        {
            return new ReplicationStatus() { Replicated = addedToSolution, ErrorMessage = errorMessage };
        }
    }
}
