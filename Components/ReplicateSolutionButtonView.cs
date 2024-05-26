using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class ReplicateSolutionButtonView
    {
        private readonly Button replicateSolutionButton;
        private readonly LogService logService;

        private readonly string noTargetConnectionText = "Connect to target environment";

        public ReplicateSolutionButtonView(Component replicateSolutionButton, LogService logService)
        {
            this.replicateSolutionButton = (Button)replicateSolutionButton;
            this.logService = logService;
            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }
        public void DisableComponent(bool isDisabled)
        {
            if (this.replicateSolutionButton.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.replicateSolutionButton.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.replicateSolutionButton.Enabled = !isDisabled;
            }
        }
    }
}
