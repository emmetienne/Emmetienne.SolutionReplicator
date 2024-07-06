using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class OpenExportSolutionFolderPathView
    {
        private readonly Button openExportFolderSolutionButton;
        private readonly LogService logService;

        private readonly string exportSolutionMessage = "Download target solution";

        public OpenExportSolutionFolderPathView(Component exportTargetSolutionButton, LogService logService)
        {
            this.openExportFolderSolutionButton = (Button)exportTargetSolutionButton;
            this.logService = logService;

            this.openExportFolderSolutionButton.Click += InitOpenExportSolutionFolderPathPromptExport;

            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        private void InitOpenExportSolutionFolderPathPromptExport(object sender, EventArgs e)
        {
            EventBus.EventBusSingleton.Instance.openExportSolutionPathPrompt?.Invoke();
        }

        public void DisableComponent(bool isDisabled)
        {
            if (this.openExportFolderSolutionButton.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.openExportFolderSolutionButton.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.openExportFolderSolutionButton.Enabled = !isDisabled;
            }
        }
    }
}