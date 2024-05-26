using Emmetienne.SolutionReplicator.Services;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class TargetEnvirontmentLabelView
    {
        private readonly ToolStripButton targetEnvironmentButton;
        private readonly LogService logService;

        private readonly string noTargetConnectionText = "Connect to target environment";

        public TargetEnvirontmentLabelView(Component targetEnvirontmentButton, LogService logService)
        {
            this.targetEnvironmentButton = (ToolStripButton)targetEnvirontmentButton;
            this.logService = logService;
            EventBus.EventBusSingleton.Instance.setTargetEnvironmentName += SetButtonLabel;
            EventBus.EventBusSingleton.Instance.clearTargetEnvironmentName += ClearButtonLabel;
        }

        private void SetButtonLabel(string label)
        {
            this.targetEnvironmentButton.Text = $"Target envinronment: {label}";
        }

        private void ClearButtonLabel()
        {
            this.targetEnvironmentButton.Text = noTargetConnectionText;
        }
    }
}
