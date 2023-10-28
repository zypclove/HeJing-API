// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System;
using System.Threading.Tasks;
using IdentityServer.Admin.BusinessLogic.Dtos.Log;

namespace IdentityServer.Admin.BusinessLogic.Services.Interfaces
{
    public interface ILogService
    {
        Task<LogsDto> GetLogsAsync(string search, int page = 1, int pageSize = 10);

        Task DeleteLogsOlderThanAsync(DateTime deleteOlderThan);
    }
}