using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class BrowseExportSolutionPathButtonView
    {
        private readonly Button browseSolutionExportPathTextBox;
        private readonly LogService logService;

        public BrowseExportSolutionPathButtonView(Component solutionGridViewComponent, LogService logService)
        {
            this.browseSolutionExportPathTextBox = (Button)solutionGridViewComponent;
            this.logService = logService;

            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        public void DisableComponent(bool isDisabled)
        {
            if (this.browseSolutionExportPathTextBox.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.browseSolutionExportPathTextBox.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.browseSolutionExportPathTextBox.Enabled = !isDisabled;
            }
        }
    }
}
