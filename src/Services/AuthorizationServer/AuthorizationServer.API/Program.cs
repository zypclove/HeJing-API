using AuthorizationServer.API.Core;
using AuthorizationServer.Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Quartz;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
var services = builder.Services;

builder.Services.AddCors();
builder.Services.AddControllers();
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
        {
            options.LoginPath = "/Identity/Account/Login";
        });

// OpenIddict 提供与 Quartz.NET 的本机集成，以定期执行计划任务（例如从数据库中修剪孤立的授权/令牌）。
builder.Services.AddQuartz(options =>
{
    options.UseMicrosoftDependencyInjectionJobFactory();
    options.UseSimpleTypeLoader();
    options.UseInMemoryStore();
});

// 注册 Quartz.NET 服务并将其配置为阻止关闭，直到作业完成。
builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

var connectionString = builder.Configuration.GetConnectionString("AuthorizationServerDbConnection") ?? throw new InvalidOperationException("Connection string 'AuthorizationServerDbConnection' not found.");

builder.Services.AddDbContext<AuthorizationServerDbContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("AuthorizationServer.API"));

    // 注册OpenIddict需要的实体集。
    // 注意：如果需要，请使用通用重载替换默认的 OpenIddict 实体。
    options.UseOpenIddict();
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// 注册身份服务。
builder.Services
    .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthorizationServerDbContext>();

builder.Services.AddOpenIddict()
    // 注册 OpenIddict 核心组件。
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore()
               .UseDbContext<AuthorizationServerDbContext>();
    })
    // 注册 OpenIddict 服务器组件。
    .AddServer(options =>
    {
        // 启用授权、内省和令牌端点。
        options
            .SetAuthorizationEndpointUris("/connect/authorize")
            .SetUserinfoEndpointUris("/connect/userinfo")
            .SetIntrospectionEndpointUris("/connect/introspect")
            .SetTokenEndpointUris("/connect/token");

        //注意：此示例仅使用授权代码和刷新令牌流，但如果您需要支持隐式、密码或客户端凭据，则可以启用其他流。
        options
            .AllowPasswordFlow()
            .AllowClientCredentialsFlow()
            .AllowAuthorizationCodeFlow()
            .AllowRefreshTokenFlow();

        // 注册加密凭据。 此示例使用在服务器和 Api2 示例之间共享的对称加密密钥（执行本地令牌验证而不是使用内省）。
        // 注意：在现实世界的应用程序中，此加密密钥应存储在安全的地方（例如，在 Azure KeyVault 中，作为秘密存储）。
        options.AddEncryptionKey(new SymmetricSecurityKey(
            Convert.FromBase64String("DRjd/GnduI3Efzen9V9BvbNUfc/VKgXltV7Kbk9sMkY=")));

        // 注册签名凭据。
        options.AddDevelopmentSigningCertificate();

        // 注册 ASP.NET Core 主机并配置 ASP.NET Core 特定的选项。
        // 注意：与其他示例不同，此示例不使用令牌端点传递来处理自定义 MVC 操作中的令牌请求。 因此，令牌请求将由 OpenIddict 自动处理，它将重用从授权代码解析的身份来生成访问令牌和身份令牌。
        options
            .UseAspNetCore()
            .EnableTokenEndpointPassthrough()
            .EnableAuthorizationEndpointPassthrough()
            .EnableUserinfoEndpointPassthrough()
            .DisableTransportSecurityRequirement();// 在开发过程中，您可以禁用 HTTPS 要求。
    })
    // 注册 OpenIddict 验证组件。
    .AddValidation(options =>
    {
        // 从本地 OpenIddict 服务器实例导入配置。
        options.UseLocalServer();

        // 注册 ASP.NET Core 主机。
        options.UseAspNetCore();
    });

// 注册负责使用示例客户端播种数据库的工作人员。
// 注意：在现实世界的应用程序中，此步骤应该是设置脚本的一部分。
builder.Services.AddHostedService<Worker>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseCors(b => b.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:5112"));
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();

app.Run();
