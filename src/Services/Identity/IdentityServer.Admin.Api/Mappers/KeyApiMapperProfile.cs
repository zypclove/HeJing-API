﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using AutoMapper;
using IdentityServer.Admin.Api.Dtos.Key;
using IdentityServer.Admin.BusinessLogic.Dtos.Key;

namespace IdentityServer.Admin.Api.Mappers
{
    public class KeyApiMapperProfile : Profile
    {
        public KeyApiMapperProfile()
        {
            CreateMap<KeyDto, KeyApiDto>(MemberList.Destination)
                .ReverseMap();

            CreateMap<KeysDto, KeysApiDto>(MemberList.Destination)
                .ReverseMap();
        }
    }
}