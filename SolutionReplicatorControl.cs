using Emmetienne.SolutionReplicator.Components;
using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System;
using XrmToolBox.Extensibility;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Emmetienne.SolutionReplicator
{
    public partial class SolutionReplicatorControl : MultipleConnectionsPluginControlBase
    {
        private Settings mySettings;
        private LogService logService;
        private SolutionRetrieverService solutionRetrieverService;
        private SolutionComponentRetrieverService solutionComponentRetrieverService;
        private SolutionReplicatorService solutionReplicatorService;
        private PublisherRetrieverService publisherRetrieverService;
        private SolutionReplicatorValidationService solutionReplicatorValidationService;
        private SolutionViewBase solutionGridViewComponent;
        private SolutionComponentViewBase solutionComponentsGridViewComponent;
        private PublisherComboBoxView publisherComboBoxViewComponent;
        private SourceEnvirontmentLabelView sourceEnvirontmentLabelView;
        private TargetEnvirontmentLabelView targetEnvirontmentLabelView;
        private ReplicateSolutionButtonView replicateSolutionButtonView;
        private ILoggingComponent loggingComponent;


        public SolutionReplicatorControl()
        {
            InitializeComponent();

            this.logService = new LogService();

            this.loggingComponent = new LoggingComponent(this.logDataGridView);
            this.solutionGridViewComponent = new SolutionGridViewComponent(this.solutionGridView, logService);
            this.solutionComponentsGridViewComponent = new SolutionComponentsGridView(this.solutionComponentDataGridView, logService);
            this.publisherComboBoxViewComponent = new PublisherComboBoxView(this.publisherComboBox, logService);
            this.sourceEnvirontmentLabelView = new SourceEnvirontmentLabelView(this.tsbLoadSolution, logService);
            this.targetEnvirontmentLabelView = new TargetEnvirontmentLabelView(this.tsbSecondEnvinronment, logService);
            this.replicateSolutionButtonView = new ReplicateSolutionButtonView(this.replicateSolutionButton, logService);
        }

        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("Visit my GitHub", new Uri("https://github.com/emmetienne"));

            this.solutionRetrieverService = new SolutionRetrieverService(logService, this);
            this.solutionComponentRetrieverService = new SolutionComponentRetrieverService(logService, Service, this);
            this.solutionReplicatorValidationService = new SolutionReplicatorValidationService(logService, this);
        }

        private void tsbLoadSolution_Click(object sender, EventArgs e)
        {
            ExecuteMethod(GetSolutions);
        }

        private void GetSolutions()
        {
            this.solutionRetrieverService.GetSolutions();
        }

        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            if (Service == newService)
                return;

            base.UpdateConnection(newService, detail, actionName, parameter);

            if (actionName.Equals("AdditionalOrganization", StringComparison.OrdinalIgnoreCase))
                return;

            EventBus.EventBusSingleton.Instance.changeSourceOrganizationService?.Invoke(this.Service);
            EventBus.EventBusSingleton.Instance.setSourceEnvironmentName?.Invoke(detail.ConnectionName);
            EventBus.EventBusSingleton.Instance.clearAllViews?.Invoke();


            if (this.AdditionalConnectionDetails.Count > 0)
            {
                ComponentTypeCache.Instance.HandleComponentCache(this.Service, this.AdditionalConnectionDetails[0].GetCrmServiceClient());
                ComponentTypeCache.Instance.InvalidateDynamicCache();
            }

            logService.LogWarning($"Source environment connection has changed to: {this.ConnectionDetail.WebApplicationUrl}");
        }

        private void replicateSolutionButton_Click(object sender, EventArgs e)
        {
            var dataBinded = solutionComponentDataGridView.Rows;

            if (dataBinded == null)
                return;

            var targetSolutionSettings = new TargetSolutionSettings(this.solutionNameTextBox.Text, (Guid?)this.publisherComboBox.SelectedValue,
                                                                    this.pruneComponentcheckBox.Checked, this.versionTextBox.Text);

            if (!solutionReplicatorValidationService.Validate(targetSolutionSettings))
                return;

            var secondService = this.AdditionalConnectionDetails[0].GetCrmServiceClient();

            this.solutionReplicatorService = new SolutionReplicatorService(logService, Service, secondService, this);

            solutionReplicatorService.ReplicateSolution(this.solutionComponentsGridViewComponent.SolutionComponents, targetSolutionSettings);
        }

        private void tsbSecondEnvinronment_Click(object sender, EventArgs e)
        {
            EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(true);

            AddAdditionalOrganization();

            if (this.AdditionalConnectionDetails.Count == 0)
            {
                EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(false);
                return;
            }

            if (this.AdditionalConnectionDetails != null && this.AdditionalConnectionDetails.Count > 1)
                this.RemoveAdditionalOrganization(this.AdditionalConnectionDetails[0]);

            EventBus.EventBusSingleton.Instance.setTargetEnvironmentName?.Invoke(this.AdditionalConnectionDetails[0].ConnectionName);

            this.publisherRetrieverService = new PublisherRetrieverService(logService, this.AdditionalConnectionDetails[0].GetCrmServiceClient(), this);
            this.publisherRetrieverService.GetPublishers();

            ComponentTypeCache.Instance.InvalidateDynamicCache();
            ComponentTypeCache.Instance.HandleComponentCache(this.Service, this.AdditionalConnectionDetails[0].GetCrmServiceClient());
            EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(false);

            logService.LogWarning($"Target environment connection has changed to: {this.AdditionalConnectionDetails[0].WebApplicationUrl}");
        }
    }
}
