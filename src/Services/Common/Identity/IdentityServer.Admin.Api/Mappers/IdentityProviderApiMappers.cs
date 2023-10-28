// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Collections.Generic;
using AutoMapper;
using Duende.IdentityServer.EntityFramework.Entities;
using IdentityServer.Admin.BusinessLogic.Dtos.IdentityProvider;
using IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer.Admin.Api.Mappers
{
    public static class IdentityProviderApiMappers
    {
        static IdentityProviderApiMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<IdentityProviderApiMapperProfile>())
                .CreateMapper();
        }

        internal static IMapper Mapper { get; }
        public static T ToIdentityProviderApiModel<T>(this object source)
        {
            return Mapper.Map<T>(source);
        }

    }
}