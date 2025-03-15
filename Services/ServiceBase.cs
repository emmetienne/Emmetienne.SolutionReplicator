using Microsoft.Xrm.Sdk;

namespace Emmetienne.SolutionReplicator.Services
{
    abstract class ServiceBase
    {
        public abstract void ChangeMainConnection(IOrganizationService service);
        public virtual void ChangeSecondaryConnection(IOrganizationService service) { return; }
    }
}
