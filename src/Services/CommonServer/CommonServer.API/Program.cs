using CommonServer.API.Mappers;
using CommonServer.HostApp.Services;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var services = builder.Services;

// Add services to the container.

services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});


services.AddDbContext<CommonServerDbContext>(options =>
{
    options.EnableSensitiveDataLogging(true);
    options.UseSqlServer(configuration.GetConnectionString("CommonServerDbConnection")!, b => b.MigrationsAssembly("CommonServer.API"));
});

services.Scan(
    scan => scan
    .FromAssemblyOf<AppsService>()
    .AddClasses(classes => classes.Where(
        t => t.Name.EndsWith("Service", StringComparison.Ordinal)))
    .AsSelf()
    .WithScopedLifetime());

services.AddAutoMapper(typeof(DtoToDomainProfile));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.ConfigureSwaggerGen(options =>
{
    options.CustomSchemaIds(x => x.FullName);
});
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapGet("/test", (IConfiguration configuration) =>
{
    return $"{Assembly.GetExecutingAssembly().FullName};当前时间：{DateTime.Now}";
});

app.MapControllers();

app.Run();