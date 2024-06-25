using Emmetienne.SolutionReplicator.Repository;
using Microsoft.Xrm.Sdk;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Emmetienne.SolutionReplicator.Services
{
    internal class ExportSolutionService
    {
        private readonly LogService logService;
        private readonly IOrganizationService sourceOrganizationservice;
        private readonly IOrganizationService targetOrganizationService;
        private readonly PluginControlBase pluginControlBase;
        private SolutionRepository sourceSolutionRepository;
        private SolutionRepository targetSolutionRepository;
        private string sourceSolutionUniqueName;
        private string targetSolutionUniqueName;
        private string exportSolutionPath;
        private Settings settings;

        public ExportSolutionService(LogService logService, IOrganizationService organizationService, MultipleConnectionsPluginControlBase pluginControlBase, Settings settings = null)
        {
            this.logService = logService;
            this.pluginControlBase = pluginControlBase;

            this.targetOrganizationService = organizationService;
            this.sourceSolutionRepository = new SolutionRepository(organizationService, logService);


            if (pluginControlBase.AdditionalConnectionDetails.Count > 0)
            {
                this.targetOrganizationService = pluginControlBase.AdditionalConnectionDetails[0].GetCrmServiceClient();
                this.targetSolutionRepository = new SolutionRepository(organizationService, logService);
            }


            EventBus.EventBusSingleton.Instance.emitSourceSolutionUniqueName += ChangeSourceSolutionUniqueName;
            EventBus.EventBusSingleton.Instance.emitTargetSolutionUniqueName += ChangetargetSolutionUniqueName;
            EventBus.EventBusSingleton.Instance.emitExportSolutionPath += ChangeExportSolutionPath;
            EventBus.EventBusSingleton.Instance.changeSourceOrganizationService += ChangeMainConnection;
            EventBus.EventBusSingleton.Instance.changeTargetOrganizationService += ChangeTargetConnection;
            EventBus.EventBusSingleton.Instance.clearAllViews += ClearExportButtonsLabels;
            EventBus.EventBusSingleton.Instance.clearSolutionComponentView += ClearTargetExportButtonsLabels;
            EventBus.EventBusSingleton.Instance.startExportSolution += ExportSolution;

            this.settings = settings;

            if (!string.IsNullOrWhiteSpace(this.settings.SolutionExportPath))
            {
                EventBus.EventBusSingleton.Instance.emitExportSolutionPathFromFolderBrowser?.Invoke(settings.SolutionExportPath);
                exportSolutionPath = this.settings.SolutionExportPath;
            }
        }

        public void ChangeMainConnection(IOrganizationService service)
        {
            this.sourceSolutionRepository = new SolutionRepository(service, logService);
        }

        public void ChangeTargetConnection(IOrganizationService service)
        {
            this.targetSolutionRepository = new SolutionRepository(service, logService);
        }

        public void ChangeExportSolutionPath(string exportSolutionPath)
        {
            this.exportSolutionPath = exportSolutionPath;
            settings.SolutionExportPath = exportSolutionPath;

            SettingsManager.Instance.Save(typeof(SolutionReplicatorControl), settings);
        }

        private void ClearExportButtonsLabels()
        {
            EventBus.EventBusSingleton.Instance.emitSourceSolutionUniqueName?.Invoke(string.Empty);
            EventBus.EventBusSingleton.Instance.emitTargetSolutionUniqueName?.Invoke(string.Empty);
        }

        private void ClearTargetExportButtonsLabels()
        {
            EventBus.EventBusSingleton.Instance.emitTargetSolutionUniqueName?.Invoke(string.Empty);
        }

        public void ChangeSourceSolutionUniqueName(string solutionUniqueName)
        {
            this.sourceSolutionUniqueName = solutionUniqueName;
        }

        public void ChangetargetSolutionUniqueName(string solutionUniqueName)
        {
            this.targetSolutionUniqueName = solutionUniqueName;
        }

        public void ExportSolution(bool exportFromSourceEnironment)
        {
            var spinnerMessage = exportFromSourceEnironment ? $"Exporting solution {sourceSolutionUniqueName} from source environment" : $"Exporting solution {targetSolutionUniqueName} from target environment";

            pluginControlBase.WorkAsync(new WorkAsyncInfo
            {
                Message = spinnerMessage,
                Work = (worker, args) =>
                {
                    try
                    {
                        var environmentMessage = exportFromSourceEnironment ? "source" : "target";

                        logService.LogInfo($"Exporting solution {sourceSolutionUniqueName} from {environmentMessage} environment");
                        EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(true);

                        var solutionNameToUse = exportFromSourceEnironment ? sourceSolutionUniqueName : targetSolutionUniqueName;


                        if (string.IsNullOrEmpty(solutionNameToUse))
                        {
                            logService.LogError($"No solution has been selected for {environmentMessage} environment");
                            return;
                        }

                        byte[] solutionByteData = exportFromSourceEnironment ? sourceSolutionRepository.ExportSoluton(sourceSolutionUniqueName) : targetSolutionRepository.ExportSoluton(targetSolutionUniqueName);


                        if (!Directory.Exists(exportSolutionPath))
                            Directory.CreateDirectory(exportSolutionPath);

                        File.WriteAllBytes($"{exportSolutionPath}\\{solutionNameToUse}.zip", solutionByteData);

                        Process.Start("explorer.exe", exportSolutionPath);

                        logService.LogInfo($"Solution {sourceSolutionUniqueName} from {environmentMessage} environment exported succesfully");
                    }
                    catch (Exception ex)
                    {
                        logService.LogError("Error exporting solution", ex.Message);
                    }
                },
                PostWorkCallBack = (args) =>
                {
                    EventBus.EventBusSingleton.Instance.disableUiElements?.Invoke(false);
                }
            });
        }

        public void OpenSelectionFolderDialog()
        {
            var folderBrowserDialog = new FolderBrowserDialog();

            var result = folderBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
            {
                EventBus.EventBusSingleton.Instance.emitExportSolutionPathFromFolderBrowser?.Invoke(folderBrowserDialog.SelectedPath);
            }
        }
    }
}
