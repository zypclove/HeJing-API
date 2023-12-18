// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Skoruba.AuditLogging.Events;
using IdentityServer.Admin.BusinessLogic.Dtos.IdentityProvider;

namespace IdentityServer.Admin.BusinessLogic.Events.IdentityProvider
{
    public class IdentityProviderAddedEvent : AuditEvent
    {
        public IdentityProviderDto IdentityProvider { get; set; }

        public IdentityProviderAddedEvent(IdentityProviderDto identityProvider)
        {
            IdentityProvider = identityProvider;
        }
    }
}