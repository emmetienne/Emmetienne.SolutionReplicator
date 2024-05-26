using Microsoft.Xrm.Sdk;

namespace Emmetienne.SolutionReplicator.Services
{
    abstract class ServiceBase
    {
        public abstract void ChangeMainConnection(IOrganizationService service);
        public abstract void ChangeTargetConnection(IOrganizationService service);
    }
}
