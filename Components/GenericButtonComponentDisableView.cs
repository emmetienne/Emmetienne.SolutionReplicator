using Emmetienne.SolutionReplicator.Services;
using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class GenericButtonComponentDisableView
    {
        private readonly Button component;
        private readonly LogService logService;
        public GenericButtonComponentDisableView(Component component, LogService logService)
        {
            this.component = (Button) component;
            this.logService = logService;

            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

  
        public void DisableComponent(bool isDisabled)
        {
            if (this.component.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.component.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.component.Enabled = !isDisabled;
            }
        }
    }
}
