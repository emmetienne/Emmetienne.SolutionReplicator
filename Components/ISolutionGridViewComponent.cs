using Emmetienne.SolutionReplicator.Model;
using System;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Components
{
    public interface ISolutionGridViewComponent
    {
        void FillGrid(List<SolutionWrapper> list);
        void OnCellSelection(object sender, EventArgs e);
    }
}
