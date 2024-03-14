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

// OpenIddict �ṩ�� Quartz.NET �ı������ɣ��Զ���ִ�мƻ�������������ݿ����޼���������Ȩ/���ƣ���
builder.Services.AddQuartz(options =>
{
    options.UseMicrosoftDependencyInjectionJobFactory();
    options.UseSimpleTypeLoader();
    options.UseInMemoryStore();
});

// ע�� Quartz.NET ���񲢽�������Ϊ��ֹ�رգ�ֱ����ҵ��ɡ�
builder.Services.AddQuartzHostedService(options => options.WaitForJobsToComplete = true);

var connectionString = builder.Configuration.GetConnectionString("AuthorizationServerDbConnection") ?? throw new InvalidOperationException("Connection string 'AuthorizationServerDbConnection' not found.");

builder.Services.AddDbContext<AuthorizationServerDbContext>(options =>
{
    options.UseSqlServer(connectionString, b => b.MigrationsAssembly("AuthorizationServer.API"));

    // ע��OpenIddict��Ҫ��ʵ�弯��
    // ע�⣺�����Ҫ����ʹ��ͨ�������滻Ĭ�ϵ� OpenIddict ʵ�塣
    options.UseOpenIddict();
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
// ע����ݷ���
builder.Services
    .AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AuthorizationServerDbContext>();

builder.Services.AddOpenIddict()
    // ע�� OpenIddict ���������
    .AddCore(options =>
    {
        options.UseEntityFrameworkCore()
               .UseDbContext<AuthorizationServerDbContext>();
    })
    // ע�� OpenIddict �����������
    .AddServer(options =>
    {
        // ������Ȩ����ʡ�����ƶ˵㡣
        options
            .SetAuthorizationEndpointUris("/connect/authorize")
            .SetUserinfoEndpointUris("/connect/userinfo")
            .SetIntrospectionEndpointUris("/connect/introspect")
            .SetTokenEndpointUris("/connect/token");

        //ע�⣺��ʾ����ʹ����Ȩ�����ˢ�������������������Ҫ֧����ʽ�������ͻ���ƾ�ݣ������������������
        options
            .AllowPasswordFlow()
            .AllowClientCredentialsFlow()
            .AllowAuthorizationCodeFlow()
            .AllowRefreshTokenFlow();

        // ע�����ƾ�ݡ� ��ʾ��ʹ���ڷ������� Api2 ʾ��֮�乲��ĶԳƼ�����Կ��ִ�б���������֤������ʹ����ʡ����
        // ע�⣺����ʵ�����Ӧ�ó����У��˼�����ԿӦ�洢�ڰ�ȫ�ĵط������磬�� Azure KeyVault �У���Ϊ���ܴ洢����
        options.AddEncryptionKey(new SymmetricSecurityKey(
            Convert.FromBase64String("DRjd/GnduI3Efzen9V9BvbNUfc/VKgXltV7Kbk9sMkY=")));

        // ע��ǩ��ƾ�ݡ�
        options.AddDevelopmentSigningCertificate();

        // ע�� ASP.NET Core ���������� ASP.NET Core �ض���ѡ�
        // ע�⣺������ʾ����ͬ����ʾ����ʹ�����ƶ˵㴫���������Զ��� MVC �����е��������� ��ˣ����������� OpenIddict �Զ������������ô���Ȩ�����������������ɷ������ƺ�������ơ�
        options
            .UseAspNetCore()
            .EnableTokenEndpointPassthrough()
            .EnableAuthorizationEndpointPassthrough()
            .EnableUserinfoEndpointPassthrough()
            .DisableTransportSecurityRequirement();// �ڿ��������У������Խ��� HTTPS Ҫ��
    })
    // ע�� OpenIddict ��֤�����
    .AddValidation(options =>
    {
        // �ӱ��� OpenIddict ������ʵ���������á�
        options.UseLocalServer();

        // ע�� ASP.NET Core ������
        options.UseAspNetCore();
    });

// ע�Ḻ��ʹ��ʾ���ͻ��˲������ݿ�Ĺ�����Ա��
// ע�⣺����ʵ�����Ӧ�ó����У��˲���Ӧ�������ýű���һ���֡�
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
