using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class ShowSolutionComponentsNamesCheckBoxView
    {
        private readonly CheckBox getSolutionComponentsNamesCheckBox;
        private readonly LogService logService;

        public ShowSolutionComponentsNamesCheckBoxView(Component managedFilterCheckBox, LogService logService)
        {
            this.getSolutionComponentsNamesCheckBox = (CheckBox)managedFilterCheckBox;
            this.logService = logService;

            this.getSolutionComponentsNamesCheckBox.CheckedChanged += OnCheckedChange;
            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        public void OnCheckedChange(object sender, EventArgs e)
        {
            EventBus.EventBusSingleton.Instance.retrieveComponentsNames?.Invoke(this.getSolutionComponentsNamesCheckBox.Checked);
        }

        public void DisableComponent(bool isDisabled)
        {
            if (this.getSolutionComponentsNamesCheckBox.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.getSolutionComponentsNamesCheckBox.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.getSolutionComponentsNamesCheckBox.Enabled = !isDisabled;
            }
        }
    }
}
