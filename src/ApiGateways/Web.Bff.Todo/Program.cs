using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using System.IdentityModel.Tokens.Jwt;

var builder = WebApplication.CreateBuilder(args);

var gatewaySection = builder.Configuration.GetSection("Gateway");
var gwConfigFile = gatewaySection.GetValue<string>("ConfigFile");
builder.Configuration.AddJsonFile(gwConfigFile);

builder.Services.AddControllers();

var authenticationProviderKey = gatewaySection.GetValue<string>("AuthenticationProviderKey");
var identitySection = builder.Configuration.GetSection("Identity");
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(authenticationProviderKey, options =>
    {
        var identityServerUrl = identitySection.GetValue<string>("IdentityServerUrl");
        var requireHttpsMetadata = identitySection.GetValue<bool>("RequireHttpsMetadata");
        var audience = identitySection.GetValue<string>("Audience");
        options.Authority = identityServerUrl;
        options.RequireHttpsMetadata = requireHttpsMetadata;
        options.Audience = audience;
        options.TokenValidationParameters.ValidateAudience = false;
    });

builder.Services.AddOcelot();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();

app.Run();