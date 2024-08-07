﻿using System;
using System.Linq;
using System.Runtime.InteropServices;
using XrmToolBox.Extensibility;

namespace Emmetienne.SolutionReplicator.Services
{
    internal class OpenSolutionInEnvironmentService
    {
        [DllImport("shell32.dll")]
        public static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);

        private readonly LogService logService;
        private readonly MultipleConnectionsPluginControlBase multiplePluginControlBase;
        private Guid? targetSolutionId;

        public OpenSolutionInEnvironmentService(LogService logService, MultipleConnectionsPluginControlBase multiplePluginControlBase)
        {
            this.logService = logService;
            this.multiplePluginControlBase = multiplePluginControlBase;

            EventBus.EventBusSingleton.Instance.emitSolutionIdToOpenBrowser += OpenSolutionInEnvironment;
            EventBus.EventBusSingleton.Instance.clearSolutionComponentView += ClearTargetSolutionId;
            EventBus.EventBusSingleton.Instance.clearAllViews += ClearTargetSolutionId;
            EventBus.EventBusSingleton.Instance.emitTargetSolutionId += SetTargetSolutionId;
        }

        private void OpenSolutionInEnvironment(bool isSourceEnvironment, Guid? solutionId)
        {
            if (isSourceEnvironment && !solutionId.HasValue)
                return;

            if (!isSourceEnvironment && !targetSolutionId.HasValue)
            {
                logService.LogError("There's no target solution to open");
                return;
            }

            var calculatedSolutionId = solutionId.HasValue ? solutionId.Value : targetSolutionId.Value;

            var envinronmentId = string.Empty;

            if (isSourceEnvironment)
                envinronmentId = multiplePluginControlBase.ConnectionDetail?.ServiceClient?.EnvironmentId;
            else
                envinronmentId = multiplePluginControlBase.AdditionalConnectionDetails.FirstOrDefault()?.ServiceClient?.EnvironmentId;

            if (string.IsNullOrWhiteSpace(envinronmentId))
                return;

            var urlToOpen = $"https://make.powerapps.com/environments/{envinronmentId}/solutions/{calculatedSolutionId.ToString()}";

            ShellExecute(IntPtr.Zero, "open", urlToOpen, null, null, 1);
        }

        private void ClearTargetSolutionId()
        {
            SetTargetSolutionId(null);
        }

        private void SetTargetSolutionId(Guid? solutionId)
        {
            targetSolutionId = solutionId;
        }
    }
}
