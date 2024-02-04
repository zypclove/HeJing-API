// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using IdentityServer.Admin.BusinessLogic.Helpers;

namespace IdentityServer.Admin.BusinessLogic.Resources
{
    public interface IApiResourceServiceResources
    {
        ResourceMessage ApiResourceDoesNotExist();
        ResourceMessage ApiResourceExistsValue();
        ResourceMessage ApiResourceExistsKey();
        ResourceMessage ApiSecretDoesNotExist();
        ResourceMessage ApiResourcePropertyDoesNotExist();
        ResourceMessage ApiResourcePropertyExistsKey();
        ResourceMessage ApiResourcePropertyExistsValue();
    }
}