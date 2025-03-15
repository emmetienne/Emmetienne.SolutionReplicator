using Emmetienne.SolutionReplicator.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Emmetienne.SolutionReplicator.Services.ComponentNameRetrieveStrategy
{
    internal class RibbonCustomizationComponentsNameRetrieveStrategy : IComponentNameRetrieveStrategy
    {
        public void Handle(SolutionComponentWrapper componentToSearchForName, IOrganizationService organizationService, LogService logService)
        {
            var componentTypeContent = ComponentTypeCache.Instance.GetComponentTypeFromComponentTypeCode(componentToSearchForName.ComponentType);

            var primaryKeyLogicalName = !string.IsNullOrWhiteSpace(componentTypeContent.ComponentPrimaryKeyLogicalName) ? componentTypeContent.ComponentPrimaryKeyLogicalName : $"{componentTypeContent.ComponentEntityLogicalName}id";

            var componentQueryName = new QueryExpression("ribboncustomization");
            componentQueryName.NoLock = true;
            componentQueryName.ColumnSet.AddColumns(componentTypeContent.ComponentPrimaryFieldLogicalName);

            componentQueryName.Criteria.AddCondition(primaryKeyLogicalName, ConditionOperator.Equal, componentToSearchForName.ObjectId);

            var queryResults = organizationService.RetrieveMultiple(componentQueryName);

            if (queryResults.Entities.Count == 0)
            {
                logService.LogWarning($"Cannot retrieve name for component with id {componentToSearchForName.ObjectId} of type {componentToSearchForName.ComponentTypeName}, could not yet be handled by the tool ");
                return;
            }

            componentToSearchForName.ComponentName = queryResults.Entities[0].Contains(componentTypeContent.ComponentPrimaryFieldLogicalName) ? queryResults.Entities[0].GetAttributeValue<string>(componentTypeContent.ComponentPrimaryFieldLogicalName) : "Application Ribbons";
        }
    }
}
