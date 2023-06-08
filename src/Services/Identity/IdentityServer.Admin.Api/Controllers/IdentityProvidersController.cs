﻿// Copyright (c) Jan Škoruba. All Rights Reserved.
// Licensed under the Apache License, Version 2.0.

using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdentityServer.Admin.Api.Configuration.Constants;
using IdentityServer.Admin.Api.Dtos.IdentityProvider;
using IdentityServer.Admin.Api.ExceptionHandling;
using IdentityServer.Admin.Api.Mappers;
using IdentityServer.Admin.Api.Resources;
using IdentityServer.Admin.BusinessLogic.Dtos.IdentityProvider;
using IdentityServer.Admin.BusinessLogic.Services.Interfaces;

namespace IdentityServer.Admin.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [TypeFilter(typeof(ControllerExceptionFilterAttribute))]
    [Produces("application/json", "application/problem+json")]
    [Authorize(Policy = AuthorizationConsts.AdministrationPolicy)]
    public class IdentityProvidersController : ControllerBase
    {
        private readonly IIdentityProviderService _identityProviderService;
        private readonly IApiErrorResources _errorResources;

        public IdentityProvidersController(IIdentityProviderService identityProviderService, IApiErrorResources errorResources)
        {
            _identityProviderService = identityProviderService;
            _errorResources = errorResources;
        }

        [HttpGet]
        public async Task<ActionResult<IdentityProvidersApiDto>> Get(string searchText, int page = 1, int pageSize = 10)
        {
            var identityProvidersDto = await _identityProviderService.GetIdentityProvidersAsync(searchText, page, pageSize);
            var identityProvidersApiDto = identityProvidersDto.ToIdentityProviderApiModel<IdentityProvidersApiDto>();

            return Ok(identityProvidersApiDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IdentityProviderApiDto>> Get(int id)
        {
            var identityProviderDto = await _identityProviderService.GetIdentityProviderAsync(id);
            var identityProviderApiModel = identityProviderDto.ToIdentityProviderApiModel<IdentityProviderApiDto>();

            return Ok(identityProviderApiModel);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] IdentityProviderApiDto identityProviderApi)
        {
            var identityProviderDto = identityProviderApi.ToIdentityProviderApiModel<IdentityProviderDto>();

            if (!identityProviderDto.Id.Equals(default))
            {
                return BadRequest(_errorResources.CannotSetId());
            }

            var id = await _identityProviderService.AddIdentityProviderAsync(identityProviderDto);
            identityProviderApi.Id = id;

            return CreatedAtAction(nameof(Get), new { id }, identityProviderApi);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] IdentityProviderApiDto identityProviderApi)
        {
            var identityProvider = identityProviderApi.ToIdentityProviderApiModel<IdentityProviderDto>();

            await _identityProviderService.GetIdentityProviderAsync(identityProvider.Id);
            await _identityProviderService.UpdateIdentityProviderAsync(identityProvider);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var identityProvider = new IdentityProviderDto { Id = id };

            await _identityProviderService.GetIdentityProviderAsync(identityProvider.Id);
            await _identityProviderService.DeleteIdentityProviderAsync(identityProvider);

            return Ok();
        }
        
    }
}