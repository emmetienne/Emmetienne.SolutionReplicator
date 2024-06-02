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
        public Action<Guid> retrieveSolutionComponents;
        public Action<string> filterSolutionComponent;
        public Action<List<SolutionComponentWrapper>> fillSolutionComponentView;
        public Action<List<PublisherWrapper>> fillPublisherComboBox;
        public Action<string> setSourceEnvironmentName;
        public Action<string> setTargetEnvironmentName;
        public Action clearTargetEnvironmentName;
        public Action<bool> disableUiElements;
        public Action<IOrganizationService> changeSourceOrganizationService;
        public Action<IOrganizationService> changeTargetOrganizationService;
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