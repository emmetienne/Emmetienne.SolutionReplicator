using Emmetienne.SolutionReplicator.Services;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class SourceEnvironmentLabelView
    {
        private readonly ToolStripButton targetEnvironmentButton;
        private readonly LogService logService;

        private readonly string loadSolutionMessage = "Load solution from";

        public SourceEnvironmentLabelView(Component sourceEnvirontmentButton, LogService logService)
        {
            this.targetEnvironmentButton = (ToolStripButton)sourceEnvirontmentButton;
            this.logService = logService;
            EventBus.EventBusSingleton.Instance.setSourceEnvironmentName += SetButtonLabel;
        }

        private void SetButtonLabel(string label)
        {
            this.targetEnvironmentButton.Text = $"{loadSolutionMessage} {label}";
        }
    }
}
