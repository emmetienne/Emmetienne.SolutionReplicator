using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class ExportSolutionPathView
    {
        private readonly TextBox solutionExportPathTextBox;
        private readonly LogService logService;

        public ExportSolutionPathView(Component solutionGridViewComponent, LogService logService)
        {
            this.solutionExportPathTextBox = (TextBox)solutionGridViewComponent;
            this.logService = logService;

            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
            EventBus.EventBusSingleton.Instance.emitExportSolutionPathFromFolderBrowser += ChangeText;
        }

        public void OnTextChange(object sender, EventArgs e)
        {
            var textBox = (TextBox)sender;
            EventBus.EventBusSingleton.Instance.emitExportSolutionPath?.Invoke(textBox.Text);

            SettingsManager.Instance.Save(GetType(),"ExportSolutionPath", this.solutionExportPathTextBox.Text);
        }

        public void DisableComponent(bool isDisabled)
        {
            if (this.solutionExportPathTextBox.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.solutionExportPathTextBox.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.solutionExportPathTextBox.Enabled = !isDisabled;
            }
        }

        public void ChangeText(string exportPath)
        {
            if (this.solutionExportPathTextBox.InvokeRequired)
            {
                Action setTextSafe = delegate { ChangeText(exportPath); };
                this.solutionExportPathTextBox.Invoke(setTextSafe);
            }
            else
            {
                this.solutionExportPathTextBox.Text = exportPath;
            }
        }
    }
}
