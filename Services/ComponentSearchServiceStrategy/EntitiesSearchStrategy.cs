using Emmetienne.SolutionReplicator.Model;
using Emmetienne.SolutionReplicator.Services;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.ComponentSearchServiceStrategy.Strategy
{
    internal class EntitiesSearchStrategy : IComponentSearchStrategy
    {
        public FoundAndNotFoundComponents Handle(IEnumerable<SolutionComponentWrapper> componentToSearchList, IOrganizationService sourceEnvironmentService, IOrganizationService targetEnvironmentService, LogService logService)
        {
            var foundAndNotFoundComponents = new FoundAndNotFoundComponents();

            foreach (var component in componentToSearchList)
            {
                var sourceEnvEntityQuery = new QueryExpression("entity");
                sourceEnvEntityQuery.NoLock = true;
                sourceEnvEntityQuery.ColumnSet.AddColumns("logicalname");

                sourceEnvEntityQuery.Criteria.AddCondition("entityid", ConditionOperator.Equal, component.ObjectId);

                var results = sourceEnvironmentService.RetrieveMultiple(sourceEnvEntityQuery);

                if (results.Entities.Count == 0)
                {
                    foundAndNotFoundComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var entityLogicalName = results.Entities[0].GetAttributeValue<string>("logicalname");

                var targetEnvEntityQuery = new QueryExpression("entity");
                targetEnvEntityQuery.NoLock = true;
                targetEnvEntityQuery.Criteria.AddCondition("logicalname", ConditionOperator.Equal, entityLogicalName);

                var targetResults = targetEnvironmentService.RetrieveMultiple(targetEnvEntityQuery);

                if (targetResults.Entities.Count == 0)
                {
                    foundAndNotFoundComponents.NotFoundComponents.Add(component);
                    continue;
                }

                var tmpTargetComponentWrapper = new SolutionComponentWrapper();
                tmpTargetComponentWrapper.ObjectId = targetResults.Entities[0].Id;
                tmpTargetComponentWrapper.ComponentType = 1;
                foundAndNotFoundComponents.FoundComponents.Add(tmpTargetComponentWrapper);
            }

            return foundAndNotFoundComponents;
        }
    }
}
