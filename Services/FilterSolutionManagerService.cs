using Emmetienne.SolutionReplicator.Model;

namespace Emmetienne.SolutionReplicator.Services
{
    internal class FilterSolutionManagerService
    {
        private SolutionFilteringSettings solutionFilteringSettings;
        public FilterSolutionManagerService()
        {
            this.solutionFilteringSettings = new SolutionFilteringSettings();

            EventBus.EventBusSingleton.Instance.initFilterSolutions += InitFiltering;

            EventBus.EventBusSingleton.Instance.setSolutionNameFilter += FilterSolutionByName;
            EventBus.EventBusSingleton.Instance.setManagedSolutionFilter += FilterManagedSolution;
        }

        public void FilterSolutionByName(string filterText)
        {
            this.solutionFilteringSettings.SolutionName = filterText;
            InitFiltering();
        }

        public void FilterManagedSolution(bool isManaged)
        {
            this.solutionFilteringSettings.ShowManaged = isManaged;
            InitFiltering();
        }

        private void InitFiltering()
        {
            EventBus.EventBusSingleton.Instance.filterSolutions?.Invoke(this.solutionFilteringSettings);
        }
    }
}
