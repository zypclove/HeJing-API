// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using IdentityServer.Admin.BusinessLogic.Helpers;

namespace IdentityServer.Admin.BusinessLogic.Resources
{
    public interface IClientServiceResources
    {
        ResourceMessage ClientClaimDoesNotExist();

        ResourceMessage ClientDoesNotExist();

        ResourceMessage ClientExistsKey();

        ResourceMessage ClientExistsValue();

        ResourceMessage ClientPropertyDoesNotExist();

        ResourceMessage ClientSecretDoesNotExist();
    }
}
