using Emmetienne.SolutionReplicator.Model;

namespace Emmetienne.SolutionReplicator.Services.ComponentNameRetrieveStrategy
{
    internal class ComponentNameRetrieveStrategyFactory
    {
        public static IComponentNameRetrieveStrategy GetComponentNameRetrieveStrategy(int componentTypeCode)
        {
            switch (componentTypeCode)
            {
                case 9:
                    return new GlobalOptionsetsNameRetrieveStrategy();
                case 50:
                    return new RibbonCustomizationComponentsNameRetrieveStrategy();
                default:
                    break;
            }

            if (!ComponentTypeCache.Instance.ContainsKey(componentTypeCode))
                return new NotYetImplementedComponentNameRetrieve();

            return new GenericComponentsNameRetrieveStrategy();
        }
    }
}
