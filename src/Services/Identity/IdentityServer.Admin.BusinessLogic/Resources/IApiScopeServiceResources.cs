// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using IdentityServer.Admin.BusinessLogic.Helpers;

namespace IdentityServer.Admin.BusinessLogic.Resources
{
    public interface IApiScopeServiceResources
    {
        ResourceMessage ApiScopeDoesNotExist();
        ResourceMessage ApiScopeExistsValue();
        ResourceMessage ApiScopeExistsKey();
        ResourceMessage ApiScopePropertyExistsValue();
        ResourceMessage ApiScopePropertyDoesNotExist();
        ResourceMessage ApiScopePropertyExistsKey();
    }
}