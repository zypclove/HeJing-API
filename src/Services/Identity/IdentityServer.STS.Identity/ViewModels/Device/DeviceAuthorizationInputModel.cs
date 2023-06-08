﻿// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

// Original file: https://github.com/DuendeSoftware/IdentityServer.Quickstart.UI
// Modified by Jan Škoruba

using IdentityServer.STS.Identity.ViewModels.Consent;

namespace IdentityServer.STS.Identity.ViewModels.Device
{
    public class DeviceAuthorizationInputModel : ConsentInputModel
    {
        public string UserCode { get; set; }
    }
}