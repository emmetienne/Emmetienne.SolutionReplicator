using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class OpenTargetSolutionButtonView
    {
        private readonly Button openTargetSolution;
        private readonly LogService logService;

        private readonly string exportSolutionMessage = "Download target solution";

        public OpenTargetSolutionButtonView(Component exportTargetSolutionButton, LogService logService)
        {
            this.openTargetSolution = (Button)exportTargetSolutionButton;
            this.logService = logService;

            this.openTargetSolution.Click += InitOpenTargetolutionExport;

            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        private void InitOpenTargetolutionExport(object sender, EventArgs e)
        {
            EventBus.EventBusSingleton.Instance.emitSolutionIdToOpenBrowser?.Invoke(false, null);
        }

        public void DisableComponent(bool isDisabled)
        {
            if (this.openTargetSolution.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.openTargetSolution.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.openTargetSolution.Enabled = !isDisabled;
            }
        }
    }
}