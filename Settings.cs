namespace Emmetienne.SolutionReplicator
{
    /// <summary>
    /// This class can help you to store settings for your plugin
    /// </summary>
    /// <remarks>
    /// This class must be XML serializable
    /// </remarks>
    public class Settings
    {
        public string SolutionExportPath { get; set; }
    }
}