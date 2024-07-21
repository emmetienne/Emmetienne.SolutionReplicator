using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class FilterSolutionTextBoxView
    {
        private readonly TextBox solutionFilterTextBox;
        private readonly LogService logService;

        public FilterSolutionTextBoxView(Component solutionGridViewComponent, LogService logService)
        {
            this.solutionFilterTextBox = (TextBox)solutionGridViewComponent;
            this.logService = logService;

            this.solutionFilterTextBox.TextChanged += OnTextChange;
            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        public void OnTextChange(object sender, EventArgs e)
        {
            EventBus.EventBusSingleton.Instance.setSolutionNameFilter?.Invoke(this.solutionFilterTextBox.Text);
        }

        public void DisableComponent(bool isDisabled)
        {
            if (this.solutionFilterTextBox.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.solutionFilterTextBox.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.solutionFilterTextBox.Enabled = !isDisabled;
            }
        }
    }
}
