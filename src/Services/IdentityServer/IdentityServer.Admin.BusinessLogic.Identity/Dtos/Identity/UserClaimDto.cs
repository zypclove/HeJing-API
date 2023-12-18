﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.ComponentModel.DataAnnotations;
using IdentityServer.Admin.BusinessLogic.Identity.Dtos.Identity.Base;
using IdentityServer.Admin.BusinessLogic.Identity.Dtos.Identity.Interfaces;

namespace IdentityServer.Admin.BusinessLogic.Identity.Dtos.Identity
{
    public class UserClaimDto<TKey> : BaseUserClaimDto<TKey>, IUserClaimDto
    {
        [Required]
        public string ClaimType { get; set; }

        [Required]
        public string ClaimValue { get; set; }
    }
}