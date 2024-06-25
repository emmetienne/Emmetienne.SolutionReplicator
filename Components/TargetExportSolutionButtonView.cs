using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class TargetExportSolutionButtonView
    {
        private readonly Button exportTargetSolutionButton;
        private readonly LogService logService;

        private readonly string exportSolutionMessage = "Download target solution";

        public TargetExportSolutionButtonView(Component exportTargetSolutionButton, LogService logService)
        {
            this.exportTargetSolutionButton = (Button)exportTargetSolutionButton;
            this.logService = logService;

            this.exportTargetSolutionButton.Click += InitTargetolutionExport;

            EventBus.EventBusSingleton.Instance.emitTargetSolutionUniqueName += SetButtonLabel;
            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        private void InitTargetolutionExport(object sender, EventArgs e)
        {
            EventBus.EventBusSingleton.Instance.startExportSolution?.Invoke(false);
        }

        private void SetButtonLabel(string label)
        {
            if (this.exportTargetSolutionButton.InvokeRequired)
            {
                Action setButtonLabelSafe = delegate { SetButtonLabelSafe(label); };
                this.exportTargetSolutionButton.Invoke(setButtonLabelSafe);
            }
            else
            {
                SetButtonLabelSafe(label);
            }
        }

        private void SetButtonLabelSafe(string label)
        {
            if (string.IsNullOrWhiteSpace(label))
                this.exportTargetSolutionButton.Text = exportSolutionMessage;
            else
                this.exportTargetSolutionButton.Text = $"{exportSolutionMessage} ({label})";
        }

        public void DisableComponent(bool isDisabled)
        {
            if (this.exportTargetSolutionButton.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.exportTargetSolutionButton.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.exportTargetSolutionButton.Enabled = !isDisabled;
            }
        }
    }
}