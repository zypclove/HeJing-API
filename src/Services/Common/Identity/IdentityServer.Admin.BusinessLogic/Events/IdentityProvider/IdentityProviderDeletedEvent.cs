// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Skoruba.AuditLogging.Events;
using IdentityServer.Admin.BusinessLogic.Dtos.IdentityProvider;

namespace IdentityServer.Admin.BusinessLogic.Events.IdentityProvider
{
    public class IdentityProviderDeletedEvent : AuditEvent
    {
        public IdentityProviderDto IdentityProvider { get; set; }

        public IdentityProviderDeletedEvent(IdentityProviderDto identityProvider)
        {
            IdentityProvider = identityProvider;
        }
    }
}