﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using Skoruba.AuditLogging.Events;

namespace IdentityServer.Admin.BusinessLogic.Identity.Events.Identity
{
    public class UserPasswordChangedEvent : AuditEvent
    {
        public string UserName { get; set; }

        public UserPasswordChangedEvent(string userName)
        {
            UserName = userName;
        }
    }
}