using Emmetienne.SolutionReplicator.Model;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Components
{
    internal interface IComboBoxComponent
    {
        void FillComboBox(List<PublisherWrapper> list);
    }
}
