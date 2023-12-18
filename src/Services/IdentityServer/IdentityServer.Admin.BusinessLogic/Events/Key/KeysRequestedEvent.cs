using Skoruba.AuditLogging.Events;
using IdentityServer.Admin.BusinessLogic.Dtos.Grant;
using IdentityServer.Admin.BusinessLogic.Dtos.Key;

namespace IdentityServer.Admin.BusinessLogic.Events.Key
{
    public class KeysRequestedEvent : AuditEvent
    {
        public KeysDto Keys { get; set; }

        public KeysRequestedEvent(KeysDto keys)
        {
            Keys = keys;
        }
    }
}