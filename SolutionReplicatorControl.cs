using Emmetienne.SolutionReplicator.Components;
using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk;
using System;
using XrmToolBox.Extensibility;

namespace Emmetienne.SolutionReplicator
{
    public partial class SolutionReplicatorControl : MultipleConnectionsPluginControlBase
    {
        private Settings settings;
        private LogService logService;

        private FilterSolutionManagerService filterSolutionManagerService;
        private SolutionRetrieverService solutionRetrieverService;
        private SolutionComponentRetrieverService solutionComponentRetrieverService;
        private SolutionReplicatorService solutionReplicatorService;
        private PublisherRetrieverService publisherRetrieverService;
        private SolutionReplicatorValidationService solutionReplicatorValidationService;
        private ExportSolutionService exportSolutionService;
        private OpenSolutionInEnvironmentService openSolutionInEnvironmentService;

        private SolutionViewBase solutionGridViewComponent;
        private SolutionComponentViewBase solutionComponentsGridViewComponent;
        private PublisherComboBoxView publisherComboBoxViewComponent;
        private SourceEnvironmentLabelView sourceEnvirontmentLabelView;
        private TargetEnvironmentLabelView targetEnvirontmentLabelView;
        private ReplicateSolutionButtonView replicateSolutionButtonView;
        private SourceExportSolutionButtonView sourceExportSolutionButtonView;
        private TargetExportSolutionButtonView targetExportSolutionButtonView;
        private ExportSolutionPathView exportSolutionPathView;
        private OpenTargetSolutionButtonView openTargetSolutionButtonView;
        private OpenExportSolutionFolderPathView openExportSolutionFolderPathView;
        private FilterSolutionTextBoxView filterSolutionTextBoxView;
        private FilterManagedSolutionCheckBoxView filterManagedSolutionCheckBoxView;

        private GenericButtonComponentDisableView selectExportFolderButtonView;
        private GenericTextBoxComponentDisableView solutionNameTextBoxView;
        private GenericTextBoxComponentDisableView versionTextBoxView;

        private ILoggingComponent loggingComponent;

        public SolutionReplicatorControl()
        {
            InitializeComponent();

            this.logService = new LogService();

            ConfigureComponents();
            ConfigureViews();
        }


        private void MyPluginControl_Load(object sender, EventArgs e)
        {
            ShowInfoNotification("Visit my GitHub", new Uri("https://github.com/emmetienne"));

            LoadSettings();
            ConfigureServices();
        }

        private void ConfigureViews()
        {
            this.sourceEnvirontmentLabelView = new SourceEnvironmentLabelView(this.tsbLoadSolution, logService);
            this.targetEnvirontmentLabelView = new TargetEnvironmentLabelView(this.tsbSecondEnvinronment, logService);
            this.replicateSolutionButtonView = new ReplicateSolutionButtonView(this.replicateSolutionButton, logService);
            this.sourceExportSolutionButtonView = new SourceExportSolutionButtonView(this.exportSourceSolutionButton, logService);
            this.targetExportSolutionButtonView = new TargetExportSolutionButtonView(this.exportTargetSolutionButton, logService);
            this.exportSolutionPathView = new ExportSolutionPathView(this.exportPathTextBox, logService);
            this.openTargetSolutionButtonView = new OpenTargetSolutionButtonView(this.openTargetSolutionButton, logService);
            this.openExportSolutionFolderPathView = new OpenExportSolutionFolderPathView(this.openFolderSelectionButton, logService);
            this.filterSolutionTextBoxView = new FilterSolutionTextBoxView(this.solutionFilterTextBox, logService);
            this.filterManagedSolutionCheckBoxView = new FilterManagedSolutionCheckBoxView(this.showManagedCheckBox, logService);


            this.selectExportFolderButtonView = new GenericButtonComponentDisableView(this.openFolderSelectionButton, logService);
            this.solutionNameTextBoxView = new GenericTextBoxComponentDisableView(this.solutionNameTextBox, logService);
            this.versionTextBoxView = new GenericTextBoxComponentDisableView(this.versionTextBox, logService);
        }

        private void ConfigureComponents()
        {
            this.loggingComponent = new LoggingComponent(this.logDataGridView);
            this.solutionGridViewComponent = new SolutionGridViewComponent(this.solutionGridView, logService);
            this.solutionComponentsGridViewComponent = new SolutionComponentsGridView(this.solutionComponentDataGridView, logService);
            this.publisherComboBoxViewComponent = new PublisherComboBoxView(this.publisherComboBox, logService);
        }


        private void ConfigureServices()
        {
            this.filterSolutionManagerService = new FilterSolutionManagerService();
            this.solutionRetrieverService = new SolutionRetrieverService(logService, this);
            this.solutionComponentRetrieverService = new SolutionComponentRetrieverService(logService, Service, this);
            this.exportSolutionService = new ExportSolutionService(logService, Service, this, settings);
            this.solutionReplicatorValidationService = new SolutionReplicatorValidationService(logService, this);
            this.openSolutionInEnvironmentService = new OpenSolutionInEnvironmentService(logService, this);
        }

        private void LoadSettings()
        {
            if (SettingsManager.Instance.TryLoad(typeof(SolutionReplicatorControl), out settings))
            {
                logService.LogDebug($"Settings has been retrieved and loaded");
                EventBus.EventBusSingleton.Instance.emitExportSolutionPathFromFolderBrowser?.Invoke(settings.SolutionExportPath);
            }
            else
            {
                settings = new Settings();
                logService.LogDebug($"New settings has been created");
            }
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

        private void OnReplicateSolutionButtonClick(object sender, EventArgs e)
        {
            var dataBinded = solutionComponentDataGridView.Rows;

            if (dataBinded == null)
                return;

            var targetSolutionSettings = new TargetSolutionSettings(this.solutionNameTextBox.Text, (Guid?)this.publisherComboBox.SelectedValue,
                                                                    this.versionTextBox.Text);

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
            EventBus.EventBusSingleton.Instance.changeTargetOrganizationService?.Invoke(this.AdditionalConnectionDetails[0].GetCrmServiceClient());

            this.publisherRetrieverService = new PublisherRetrieverService(logService, this.AdditionalConnectionDetails[0].GetCrmServiceClient(), this);
            this.publisherRetrieverService.GetPublishers();

            ComponentTypeCache.Instance.InvalidateDynamicCache();
            ComponentTypeCache.Instance.HandleComponentCache(this.Service, this.AdditionalConnectionDetails[0].GetCrmServiceClient());
            EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(false);

            logService.LogWarning($"Target environment connection has changed to: {this.AdditionalConnectionDetails[0].WebApplicationUrl}");
        }
    }
}
