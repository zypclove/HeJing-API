using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

RegisterJsonFile(builder.Configuration);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

RegisterAuthentication(builder.Services);

builder.Services.AddOcelot();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseOcelot().Wait();

app.Run();

// ÑéÖ¤
static void RegisterAuthentication(IServiceCollection services)
{
    var authenticationProviderKey = "OcelotKey";
    services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(authenticationProviderKey, options =>
                {
                    options.Authority = "https://localhost:44310";
                    options.RequireHttpsMetadata = true;
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