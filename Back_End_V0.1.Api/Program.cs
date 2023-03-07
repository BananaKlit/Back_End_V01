using BackEnd.Api.Api.Extensions;
using BackEnd.Api.Api.Features.VoitureFeature.VoitureRepository;
using BackEnd.Api.DAL.DataAccess;
using BackEnd.Api.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Net;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplicationService(builder);
builder.Services.AddScoped<IVoitureRepo, VoitureRepo>();
builder.Services.AddDbContext<MyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
           .LogTo(Console.WriteLine, LogLevel.Information));
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyOrigin();
            policy.AllowAnyMethod();
            policy.AllowAnyHeader();
        });
});
builder.WebHost.ConfigureKestrel(serverOptions =>
{
    serverOptions.Listen(IPAddress.Any, 80);
    serverOptions.Listen(IPAddress.Any, 443, listenOptions =>
    {
        listenOptions.UseHttps();
    });
});

builder.RegisterModules();
var app = builder.Build();

app.UseExceptionHandler(app =>
{
    app.Use(async (context, next) =>
    {
        try
        {
            await next();
        }
        catch (Exception ex)
        {
            var logger = context.RequestServices.GetService<ILogger<Program>>();
            logger?.LogError(ex, "An unhandled exception has occurred. {StackTrace}", ex.StackTrace);
            throw;
        }
    });
});
app.UseCors();
app.ConfigureApplication();
app.MapEndPoints();

app.Run();
