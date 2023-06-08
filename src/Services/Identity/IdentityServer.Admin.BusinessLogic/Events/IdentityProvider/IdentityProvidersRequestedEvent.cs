using Skoruba.AuditLogging.Events;
using IdentityServer.Admin.BusinessLogic.Dtos.IdentityProvider;

namespace IdentityServer.Admin.BusinessLogic.Events.IdentityProvider
{
    public class IdentityProvidersRequestedEvent : AuditEvent
    {
        public IdentityProvidersDto IdentityProviders { get; set; }

        public IdentityProvidersRequestedEvent(IdentityProvidersDto identityProviders)
        {
            IdentityProviders = identityProviders;
        }
    }
}