using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Model.Logging;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.EventBus
{
    public class EventBusSingleton : Singleton<EventBusSingleton>
    {
        #region Actions
        public Action<List<SolutionWrapper>> fillSolutionsView;
        public Action<Guid?> emitSourceSolutionId;
        public Action<Guid?> emitTargetSolutionId;
        public Action<Guid> retrieveSolutionComponents;
        public Action<string> filterSolutionComponent;
        public Action<List<SolutionComponentWrapper>> fillSolutionComponentView;
        public Action<FoundAndNotFoundComponents> colorSolutionComponentInView;
        public Action<List<PublisherWrapper>> fillPublisherComboBox;
        public Action<string> emitSourceSolutionUniqueName;
        public Action<string> emitTargetSolutionUniqueName;
        public Action<string> emitExportSolutionPath;
        public Action<string> emitExportSolutionPathFromFolderBrowser;
        public Action<string> setSourceEnvironmentName;
        public Action<string> setTargetEnvironmentName;
        public Action<bool> disableTargetSolutionExport;
        public Action<Settings> saveSettings;
        public Action clearTargetEnvironmentName;
        public Action<bool> disableUiElements;
        public Action<IOrganizationService> changeSourceOrganizationService;
        public Action<IOrganizationService> changeTargetOrganizationService;
        public Action<bool, Guid?> emitSolutionIdToOpenBrowser;
        public Action<bool> startExportSolution;
        #endregion

        #region Logging
        public delegate void SendLog(LogModel logData);
        public delegate void ClearLog();
        public Action<LogModel> writeLog;
        #endregion

        #region UI
        public Action clearAllViews;
        public Action clearSolutionView;
        public Action clearSolutionComponentView;
        #endregion

    }
}