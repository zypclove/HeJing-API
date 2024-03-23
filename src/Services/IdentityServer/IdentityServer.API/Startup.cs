using IdentityServer.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Quartz;
using static OpenIddict.Server.OpenIddictServerEvents;

namespace IdentityServer.API;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration) => Configuration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddCors();
        services.AddRazorPages();

        var connectionString = Configuration.GetConnectionString("IdentityServerDbConnection") ?? throw new InvalidOperationException("Connection string 'IdentityServerDbConnection' not found.");

        services.AddDbContext<IdentityServerDbContext>(options =>
        {
            //options.UseSqlServer(connectionString, b => b.MigrationsAssembly("IdentityServer.API"));
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("IdentityServer.API"));

            // Register the entity sets needed by OpenIddict.
            options.UseOpenIddict();
        });

        // 注册身份服务。
        services
            .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<IdentityServerDbContext>();

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.AccessDeniedPath = "/Identity/Account/Login";
                options.LoginPath = "/Identity/Account/Login";
                options.LogoutPath = "/connect/signout";
            });

        // OpenIddict offers native integration with Quartz.NET to perform scheduled tasks
        // (like pruning orphaned authorizations/tokens from the database) at regular intervals.
        services.AddQuartz(options =>
        {
            options.UseMicrosoftDependencyInjectionJobFactory();
            options.UseSimpleTypeLoader();
            options.UseInMemoryStore();
        });

        // Register the Quartz.NET service and configure it to block shutdown until jobs are complete.
        services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

        // Register the OpenIddict services.
        services.AddOpenIddict()
            .AddCore(options =>
            {
                // Register the Entity Framework Core models/stores.
                options.UseEntityFrameworkCore()
                       .UseDbContext<IdentityServerDbContext>();

                // Enable Quartz.NET integration.
                options.UseQuartz();
            })

            .AddServer(options =>
            {
                // Enable the authorization, token, introspection and userinfo endpoints.
                options.SetAuthorizationEndpointUris(Configuration["OpenIddict:Endpoints:Authorization"]!)
                       .SetTokenEndpointUris(Configuration["OpenIddict:Endpoints:Token"]!)
                       .SetIntrospectionEndpointUris(Configuration["OpenIddict:Endpoints:Introspection"]!)
                       .SetUserinfoEndpointUris(Configuration["OpenIddict:Endpoints:Userinfo"]!)
                       .SetLogoutEndpointUris(Configuration["OpenIddict:Endpoints:Logout"]!);

                // Enable the authorization code, implicit and the refresh token flows.
                options.AllowAuthorizationCodeFlow()
                       .AllowImplicitFlow()
                       .AllowRefreshTokenFlow();

                // Expose all the supported claims in the discovery document.
                options.RegisterClaims(Configuration.GetSection("OpenIddict:Claims").Get<string[]>()!);

                // Expose all the supported scopes in the discovery document.
                options.RegisterScopes(Configuration.GetSection("OpenIddict:Scopes").Get<string[]>()!);

                // Note: an ephemeral signing key is deliberately used to make the "OP-Rotation-OP-Sig"
                // test easier to run as restarting the application is enough to rotate the keys.
                options.AddEphemeralEncryptionKey()
                       .AddEphemeralSigningKey();

                // Register the ASP.NET Core host and configure the ASP.NET Core-specific options.
                //
                // Note: the pass-through mode is not enabled for the token endpoint
                // so that token requests are automatically handled by OpenIddict.
                options.UseAspNetCore()
                       .EnableAuthorizationEndpointPassthrough()
                       .EnableAuthorizationRequestCaching()
                       .EnableLogoutEndpointPassthrough()
                       .DisableTransportSecurityRequirement();

                // Register the event handler responsible for populating userinfo responses.
                options.AddEventHandler<HandleUserinfoRequestContext>(options =>
                    options.UseSingletonHandler<Handlers.PopulateUserinfo>());
            })

            .AddValidation(options =>
            {
                // Import the configuration from the local OpenIddict server instance.
                options.UseLocalServer();

                // Register the ASP.NET Core host.
                options.UseAspNetCore();

                // Enable authorization entry validation, which is required to be able
                // to reject access tokens retrieved from a revoked authorization code.
                options.EnableAuthorizationEntryValidation();
            });

        // Register the worker responsible for creating and seeding the SQL database.
        // Note: in a real world application, this step should be part of a setup script.
        services.AddHostedService<Worker>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().WithOrigins("*"));
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
        app.UseAuthorization();

        app.UseEndpoints(endpoints => endpoints.MapRazorPages());
    }
}
