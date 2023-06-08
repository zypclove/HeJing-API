// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using IdentityServer.Admin.BusinessLogic.Helpers;

namespace IdentityServer.Admin.BusinessLogic.Resources
{
    public interface IIdentityResourceServiceResources
    {
        ResourceMessage IdentityResourceDoesNotExist();

        ResourceMessage IdentityResourceExistsKey();

        ResourceMessage IdentityResourceExistsValue();

        ResourceMessage IdentityResourcePropertyDoesNotExist();

        ResourceMessage IdentityResourcePropertyExistsValue();

        ResourceMessage IdentityResourcePropertyExistsKey();
    }
}
