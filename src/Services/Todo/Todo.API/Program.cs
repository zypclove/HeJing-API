using CommonMormon.Infrastructure.API;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Todo.API.CommandHandlers;
using Todo.API.Mappers;
using Todo.API.Options;
using Todo.API.Queries;
using Todo.Infrastructure;
using Todo.Shared.Commands.TodoItem;

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();

//AddControllers
builder.Services
    .AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
    });

//AddCors
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod();
    });
});

//AddApplicationOptions
builder.Services.Configure<AppSettings>(builder.Configuration);

//AddDbContext
builder.Services.AddDbContext<TodoDbContext>(options =>
{
    options.EnableSensitiveDataLogging(true);
    options.UseNpgsql(builder.Configuration.GetConnectionString("TodoDbConnection"), b => b.MigrationsAssembly("Todo.API"));
});

//AddCommand
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(CreateTodoItemCommand).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(CreateTodoItemCommandHandler).Assembly);
});

//AddQueries
builder.Services.Scan(
    scan => scan
    .FromAssemblyOf<TodoItemQueries>()
    .AddClasses(classes => classes.Where(
        t => t.Name.EndsWith("Queries", StringComparison.Ordinal)))
    .AsSelf()
    .WithScopedLifetime());

//AddAutoMapper
builder.Services.AddAutoMapper(typeof(DomainToResultProfile));
builder.Services.AddAutoMapper(typeof(CommandToDomainProfile));

var app = builder.Build();
app.UseServiceDefaults();

app.MapControllers();
app.Run();