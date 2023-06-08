using Skoruba.AuditLogging.Events;
using IdentityServer.Admin.BusinessLogic.Dtos.IdentityProvider;

namespace IdentityServer.Admin.BusinessLogic.Events.IdentityProvider
{
    public class IdentityProviderRequestedEvent : AuditEvent
    {
        public IdentityProviderDto IdentityProvider { get; set; }

        public IdentityProviderRequestedEvent(IdentityProviderDto identityProvider)
        {
            IdentityProvider = identityProvider;
        }
    }
}