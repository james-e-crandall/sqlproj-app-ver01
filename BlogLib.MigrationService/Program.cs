using System.Reflection;
using BlogLib.Data;
using BlogLib.MigrationService;
using Microsoft.EntityFrameworkCore;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();

builder.AddServiceDefaults();

builder.Services.AddOpenTelemetry()
    .WithTracing(tracing => tracing.AddSource(Worker.ActivitySourceName));

string? assemblyName = Assembly.GetExecutingAssembly().GetName().Name;

string? connectionStringName = "db";

builder.Services.AddDbContextPool<BlogContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString(connectionStringName), sqlOptions =>
        sqlOptions.MigrationsAssembly(assemblyName)
    ));
builder.EnrichSqlServerDbContext<BlogContext>();

var host = builder.Build();
host.Run();
