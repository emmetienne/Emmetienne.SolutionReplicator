using Emmetienne.SolutionReplicator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using XrmToolBox.Extensibility;

namespace Emmetienne.SolutionReplicator.Services
{
    internal class SolutionReplicatorValidationService
    {
        private readonly LogService logService;
        private readonly MultipleConnectionsPluginControlBase pluginControlBase;

        public SolutionReplicatorValidationService(LogService logService, MultipleConnectionsPluginControlBase pluginBase)
        {
            this.logService = logService;
            this.pluginControlBase = pluginBase;
        }

        public bool Validate(TargetSolutionSettings targetSolutionSettings)
        {
            var errorList = new List<string>();

            if (pluginControlBase.Service == null)
                errorList.Add("No source environment connection has been provided");

            if (pluginControlBase.AdditionalConnectionDetails == null || pluginControlBase.AdditionalConnectionDetails.Count == 0)
                errorList.Add("No target environment connection has been provided");

            if (pluginControlBase.Service == null)
                errorList.Add("No source environment connection has been provided");

            if (!string.IsNullOrWhiteSpace(targetSolutionSettings.SolutionName))
            {
                var checkPattern = @"^[A-Za-z0-9_]+$";

                if (!Regex.IsMatch(targetSolutionSettings.SolutionName, checkPattern))
                    errorList.Add($"{targetSolutionSettings.SolutionName} is not a valid solution name, please use only letters (a-z, A-Z), digits (0-9) or underscores (_)");
            }
            else
            {
                errorList.Add("No solution name has been provided");
            }

            if (string.IsNullOrWhiteSpace(targetSolutionSettings.Version))
                errorList.Add("No version has been provided");

            if (targetSolutionSettings.Publisher == Guid.Empty)
                errorList.Add("No Publisher has been selected");

            if (errorList.Count > 0)
            {
                MessageBox.Show($"- {string.Join($"{Environment.NewLine}- ", errorList)}", "Valdation errors", MessageBoxButtons.OK, MessageBoxIcon.Error);
                logService.LogError(string.Join($" - ", errorList));
                return false;
            }

            targetSolutionSettings.SolutionName = new string(targetSolutionSettings.SolutionName.ToCharArray().Where(c => !char.IsWhiteSpace(c)).ToArray()).Replace('.', '_');

            return true;
        }
    }
}
