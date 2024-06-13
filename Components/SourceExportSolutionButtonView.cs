using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class SourceExportSolutionButtonView
    {
        private readonly Button exportSourceButton;
        private readonly LogService logService;

        private readonly string exportSolutionMessage = "Download source solution";

        public SourceExportSolutionButtonView(Component exportSourceSolutionButton, LogService logService)
        {
            this.exportSourceButton = (Button)exportSourceSolutionButton;
            this.logService = logService;
            EventBus.EventBusSingleton.Instance.emitSourceSolutionUniqueName += SetButtonLabel;
            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        private void SetButtonLabel(string label)
        {
            if (this.exportSourceButton.InvokeRequired)
            {
                Action setButtonLabelSafe = delegate { SetButtonLabelSafe(label); };
                this.exportSourceButton.Invoke(setButtonLabelSafe);
            }
            else
            {
                SetButtonLabelSafe(label);
            }
        }

        private void SetButtonLabelSafe(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
                this.exportSourceButton.Text = exportSolutionMessage;
            else
                this.exportSourceButton.Text = $"{exportSolutionMessage} ({label})";
        }

        public void DisableComponent(bool isDisabled)
        {
            if (this.exportSourceButton.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.exportSourceButton.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.exportSourceButton.Enabled = !isDisabled;
            }
        }
    }
}
