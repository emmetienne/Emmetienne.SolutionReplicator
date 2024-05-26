using Emmetienne.SolutionReplicator.Model.Entities;
using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;

namespace Emmetienne.SolutionReplicator.Model
{
    public class SolutionComponentWrapper
    {
        public int ComponentType { get; set; }
        public string ComponentTypeName { get; set; }
        public Guid ObjectId { get; set; }
        public Guid? TargetEnvironmentObjectId { get; set; }
        public string ComponentState { get; set; }
        public int? RootComponentBehaviour { get; set; }

        public static SolutionComponentWrapper ToSolutionComponentWrapper(Entity entityRecord, Dictionary<int, string> componentTypeDictionary)
        {
            var tmpSolutionComponent = new SolutionComponentWrapper();

            tmpSolutionComponent.ComponentType = entityRecord.GetAttributeValue<OptionSetValue>(solutioncomponent.componenttype).Value;
            var rootComponentBehaviour = entityRecord.GetAttributeValue<OptionSetValue>(solutioncomponent.rootcomponentbehaviour);

            if (rootComponentBehaviour != null && rootComponentBehaviour.Value != null)
                tmpSolutionComponent.RootComponentBehaviour = rootComponentBehaviour.Value;

            if (componentTypeDictionary.ContainsKey(tmpSolutionComponent.ComponentType))
                tmpSolutionComponent.ComponentTypeName = componentTypeDictionary[tmpSolutionComponent.ComponentType];
            else
            {
                if (ComponentTypeCache.Instance.ContainsKey(tmpSolutionComponent.ComponentType))
                    tmpSolutionComponent.ComponentTypeName = ComponentTypeCache.Instance.GetComponentTypeFromComponentTypeCode(tmpSolutionComponent.ComponentType).ComponentTypeName;
                else
                    tmpSolutionComponent.ComponentTypeName = "N/A";
            }

            tmpSolutionComponent.ObjectId = entityRecord.GetAttributeValue<Guid>(solutioncomponent.objectid);

            return tmpSolutionComponent;
        }
    }
}
