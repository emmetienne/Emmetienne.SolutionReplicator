using Emmetienne.SolutionReplicator.Model;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;

namespace Emmetienne.SolutionReplicator.Services.ComponentNameRetrieveStrategy
{
    internal class GenericComponentsNameRetrieveStrategy : IComponentNameRetrieveStrategy
    {
        public void Handle(SolutionComponentWrapper componentToSearchForName, IOrganizationService organizationService, LogService logService)
        {
            var componentTypeContent = ComponentTypeCache.Instance.GetComponentTypeFromComponentTypeCode(componentToSearchForName.ComponentType);


            if (componentTypeContent == null || string.IsNullOrWhiteSpace(componentTypeContent.ComponentPrimaryFieldLogicalName))
            {
                logService.LogWarning($"Cannot retrieve name for component with id {componentToSearchForName.ObjectId} of type {componentToSearchForName.ComponentTypeName}, could not yet be handled by the tool ");
                return;
            }

            var primaryKeyLogicalName = !string.IsNullOrWhiteSpace(componentTypeContent.ComponentPrimaryKeyLogicalName) ? componentTypeContent.ComponentPrimaryKeyLogicalName : $"{componentTypeContent.ComponentEntityLogicalName}id";

            var componentQueryName = new QueryExpression(componentTypeContent.ComponentEntityLogicalName);
            componentQueryName.NoLock = true;
            componentQueryName.ColumnSet.AddColumns(componentTypeContent.ComponentPrimaryFieldLogicalName);

            componentQueryName.Criteria.AddCondition(primaryKeyLogicalName, ConditionOperator.Equal, componentToSearchForName.ObjectId);

            var queryResults = organizationService.RetrieveMultiple(componentQueryName);

            if (queryResults.Entities.Count == 0)
            {
                logService.LogWarning($"Cannot retrieve name for component with id {componentToSearchForName.ObjectId} of type {componentToSearchForName.ComponentTypeName}, could not yet be handled by the tool ");
                return;
            }

            if (componentTypeContent.ComponentPrimaryFieldType != null)
            {
                var getSourceAttributeValueMethod = typeof(Entity).GetMethod(nameof(Entity.GetAttributeValue)).MakeGenericMethod(componentTypeContent.ComponentPrimaryFieldType);
                componentToSearchForName.ComponentName = getSourceAttributeValueMethod.Invoke(queryResults.Entities[0], new object[] { componentTypeContent.ComponentPrimaryFieldLogicalName }).ToString();
            }
            else
                componentToSearchForName.ComponentName = queryResults.Entities[0].GetAttributeValue<string>(componentTypeContent.ComponentPrimaryFieldLogicalName);
        }
    }
}
