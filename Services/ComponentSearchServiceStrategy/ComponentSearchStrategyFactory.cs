using Emmetienne.SolutionReplicator.Model;

namespace Emmetienne.SolutionReplicator.ComponentSearchServiceStrategy.Strategy
{
    internal class ComponentSearchStrategyFactory
    {
        public static IComponentSearchStrategy GetComponentSearchStrategy(int componentTypeCode)
        {
            switch (componentTypeCode)
            {
                case 1:
                    return new EntitiesSearchStrategy();
                case 2:
                    return new AttributesSearchStrategy();
                case 9:
                    return new GlobalOptionsetsSearchStrategy();
                  
                case 10:
                    return new EntityRelationshipsSearchStrategy();
                case 14:
                    return new EntityKeysSearchStraregy();
                default:
                    break;
            }

            if (!ComponentTypeCache.Instance.ContainsKey(componentTypeCode))
                return null;

            return new GenericComponentSearchStrategy();
        }
    }
}
