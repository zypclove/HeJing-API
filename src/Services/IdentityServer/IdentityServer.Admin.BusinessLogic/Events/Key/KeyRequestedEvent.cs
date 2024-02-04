using Skoruba.AuditLogging.Events;
using IdentityServer.Admin.BusinessLogic.Dtos.Grant;
using IdentityServer.Admin.BusinessLogic.Dtos.Key;

namespace IdentityServer.Admin.BusinessLogic.Events.Key
{
    public class KeyRequestedEvent : AuditEvent
    {
        public KeyDto Key { get; set; }

        public KeyRequestedEvent(KeyDto key)
        {
            Key = key;
        }
    }
}