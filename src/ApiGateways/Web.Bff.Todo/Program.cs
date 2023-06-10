using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Todo.API.Options;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

var bffTodoConfiguration = configuration.GetSection(nameof(BffTodoConfiguration)).Get<BffTodoConfiguration>();
services.AddSingleton(bffTodoConfiguration);

RegisterJsonFile(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

RegisterAuthentication(builder.Services, BffTodoConfiguration bffTodoConfiguration);

builder.Services.AddOcelot();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();

app.Run();

// ÑéÖ¤
static void RegisterAuthentication(IServiceCollection services, BffTodoConfiguration bffTodoConfiguration)
{
    var authenticationProviderKey = "OcelotKey";
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(authenticationProviderKey, options =>
                {
                    options.Authority = bffTodoConfiguration.IdentityServerBaseUrl;
                    options.RequireHttpsMetadata = bffTodoConfiguration.RequireHttpsMetadata;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false
                    };
                });
}

static void RegisterJsonFile(IConfigurationBuilder builder)
{
    builder.AddJsonFile("ocelot.json");
}