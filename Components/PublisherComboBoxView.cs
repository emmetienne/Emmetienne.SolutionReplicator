using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Components
{
    internal class PublisherComboBoxView
    {
        private readonly ComboBox publisherComboBox;
        private readonly LogService logService;
        public PublisherComboBoxView(Component solutionGridViewComponent, LogService logService)
        {
            this.publisherComboBox = (ComboBox)solutionGridViewComponent;
            this.logService = logService;

            EventBus.EventBusSingleton.Instance.fillPublisherComboBox += FillComboBox;
            EventBus.EventBusSingleton.Instance.disableUiElements += DisableComponent;
        }

        public void FillComboBox(List<PublisherWrapper> list)
        {
            var publisherDictionary = list.ToDictionary(x=>x.PublisherId, x => $"({x.CustomizationPrefix}) {x.FriendlyName}");

            publisherComboBox.DataSource = new BindingSource(publisherDictionary, null);
            publisherComboBox.DisplayMember = "Value";
            publisherComboBox.ValueMember = "Key";
        }

        public void DisableComponent(bool isDisabled)
        {
            if (this.publisherComboBox.InvokeRequired)
            {
                Action setDisableComponentSafe = delegate { DisableComponent(isDisabled); };

                this.publisherComboBox.Invoke(setDisableComponentSafe);
            }
            else
            {
                this.publisherComboBox.Enabled = !isDisabled;
            }
        }
    }
}
