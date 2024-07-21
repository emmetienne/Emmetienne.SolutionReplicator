using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class FilterManagedSolutionCheckBoxView
    {
        private readonly CheckBox managedFilterCheckBox;
        private readonly LogService logService;

        public FilterManagedSolutionCheckBoxView(Component managedFilterCheckBox, LogService logService)
        {
            this.managedFilterCheckBox = (CheckBox)managedFilterCheckBox;
            this.logService = logService;

            this.managedFilterCheckBox.CheckedChanged += OnCheckedChange;
            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        public void OnCheckedChange(object sender, EventArgs e)
        {
            EventBus.EventBusSingleton.Instance.setManagedSolutionFilter?.Invoke(this.managedFilterCheckBox.Checked);
        }

        public void DisableComponent(bool isDisabled)
        {
            if (this.managedFilterCheckBox.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.managedFilterCheckBox.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.managedFilterCheckBox.Enabled = !isDisabled;
            }
        }
    }
}
