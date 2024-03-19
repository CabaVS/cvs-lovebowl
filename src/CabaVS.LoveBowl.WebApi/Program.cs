using CabaVS.LoveBowl.Application;
using CabaVS.LoveBowl.Infrastructure;
using CabaVS.LoveBowl.Presentation;
using CabaVS.LoveBowl.WebApi.Middleware;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

builder.Services
    .AddApplication()
    .AddInfrastructure()
    .AddPresentation();

var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");

app.Run();