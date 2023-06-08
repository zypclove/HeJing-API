// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using IdentityServer.Admin.BusinessLogic.Identity.Helpers;

namespace IdentityServer.Admin.BusinessLogic.Identity.Resources
{
    public interface IPersistedGrantAspNetIdentityServiceResources
    {
        ResourceMessage PersistedGrantDoesNotExist();

        ResourceMessage PersistedGrantWithSubjectIdDoesNotExist();
    }
}
