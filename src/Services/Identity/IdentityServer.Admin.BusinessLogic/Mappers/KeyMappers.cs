// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using AutoMapper;
using Duende.IdentityServer.EntityFramework.Entities;
using IdentityServer.Admin.BusinessLogic.Dtos.Grant;
using IdentityServer.Admin.BusinessLogic.Dtos.Key;
using IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer.Admin.BusinessLogic.Mappers
{
    public static class KeyMappers
    {
        internal static IMapper Mapper { get; }

        static KeyMappers()
        {
            Mapper = new MapperConfiguration(cfg => cfg.AddProfile<KeyMapperProfile>())
                .CreateMapper();
        }

        public static KeyDto ToModel(this Key key)
        {
            return key == null ? null : Mapper.Map<KeyDto>(key);
        }

        public static KeysDto ToModel(this PagedList<Key> grant)
        {
            return grant == null ? null : Mapper.Map<KeysDto>(grant);
        }
    }
}