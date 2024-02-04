// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using Duende.IdentityServer.Models;
using Client = IdentityServer.Admin.EntityFramework.Configuration.Configuration.IdentityServer.Client;

namespace IdentityServer.Admin.EntityFramework.Configuration.Configuration
{
    public class IdentityServerData
    {
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<IdentityResource> IdentityResources { get; set; } = new List<IdentityResource>();
        public List<ApiResource> ApiResources { get; set; } = new List<ApiResource>();
        public List<ApiScope> ApiScopes { get; set; } = new List<ApiScope>();
    }
}
