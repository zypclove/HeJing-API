// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using AutoMapper;
using Duende.IdentityServer.EntityFramework.Entities;
using IdentityServer.Admin.BusinessLogic.Dtos.Grant;
using IdentityServer.Admin.BusinessLogic.Dtos.Key;
using IdentityServer.Admin.EntityFramework.Extensions.Common;

namespace IdentityServer.Admin.BusinessLogic.Mappers
{
    public class KeyMapperProfile : Profile
    {
        public KeyMapperProfile()
        {
            CreateMap<PagedList<Key>, KeysDto>(MemberList.Destination)
                .ForMember(x => x.Keys,
                    opt => opt.MapFrom(src => src.Data));

            CreateMap<Key, KeyDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}