using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.Reflection;
using Todo.API.CommandHandlers;
using Todo.API.Mappers;
using Todo.API.Options;
using Todo.API.Queries;
using Todo.Infrastructure;
using Todo.Shared.Commands.TodoItem;

var builder = WebApplication.CreateBuilder(args);

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var configuration = builder.Configuration;
var services = builder.Services;

var todoAPIConfiguration = configuration.GetSection(nameof(TodoApiConfiguration)).Get<TodoApiConfiguration>();
services.AddSingleton(todoAPIConfiguration);
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


services.AddDbContext<TodoDbContext>(options =>
{
    options.EnableSensitiveDataLogging(true);
    options.UseNpgsql(configuration.GetConnectionString("TodoDbConnection"), b => b.MigrationsAssembly("Todo.API"));
});

services.Scan(
    scan => scan
    .FromAssemblyOf<TodoItemQueries>()
    .AddClasses(classes => classes.Where(
        t => t.Name.EndsWith("Queries", StringComparison.Ordinal)))
    .AsSelf()
    .WithScopedLifetime());

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTodoItemCommand).Assembly));
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateTodoItemCommandHandler).Assembly));

services.AddAutoMapper(typeof(DomainToResultProfile));
services.AddAutoMapper(typeof(CommandToDomainProfile));

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