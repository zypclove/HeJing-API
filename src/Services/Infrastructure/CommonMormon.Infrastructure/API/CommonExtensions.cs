using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;

namespace CommonMormon.Infrastructure.API;

public static class CommonExtensions
{
    public static WebApplicationBuilder AddServiceDefaults(this WebApplicationBuilder builder)
    {
        builder.Services.AddDefaultAuthentication(builder.Configuration);
        builder.Services.AddDefaultOpenApi(builder.Configuration);

        return builder;
    }

    public static WebApplication UseServiceDefaults(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.UseCors();

        app.UseDefaultAuthentication(app.Configuration);
        app.UseDefaultOpenApi(app.Configuration);

        app.MapGet("/test", (IConfiguration configuration) =>
        {
            return $"当前时间：{DateTime.Now}";
        });

        return app;
    }
    public static IServiceCollection AddDefaultAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var identitySection = configuration.GetSection("Identity");

        if (!identitySection.Exists())
        {
            return services;
        }

        JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            var identityServerUrl = identitySection.GetValue<string>("IdentityServerUrl");
            var requireHttpsMetadata = identitySection.GetValue<bool>("RequireHttpsMetadata");
            var audience = identitySection.GetValue<string>("Audience");
            options.Authority = identityServerUrl;
            options.RequireHttpsMetadata = requireHttpsMetadata;
            options.Audience = audience;
            options.TokenValidationParameters.ValidateAudience = false;
        });

        return services;
    }

    public static IServiceCollection AddDefaultOpenApi(this IServiceCollection services, IConfiguration configuration)
    {
        var openApi = configuration.GetSection("OpenApi");

        if (!openApi.Exists())
        {
            return services;
        }

        services.AddEndpointsApiExplorer();
        services.ConfigureSwaggerGen(options =>
        {
            options.CustomSchemaIds(x => x.FullName);
        });
        services.AddSwaggerGen();

        return services;
    }

    public static IApplicationBuilder UseDefaultAuthentication(this WebApplication app, IConfiguration configuration)
    {
        var identitySection = configuration.GetSection("Identity");

        if (!identitySection.Exists())
        {
            return app;
        }

        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }

    public static IApplicationBuilder UseDefaultOpenApi(this WebApplication app, IConfiguration configuration)
    {
        var openApiSection = configuration.GetSection("OpenApi");

        if (!openApiSection.Exists())
        {
            return app;
        }

        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
