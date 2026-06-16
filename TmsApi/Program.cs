using Microsoft.AspNetCore.Authentication;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services
    .AddAuthentication("Training")
    .AddScheme<AuthenticationSchemeOptions, TrainingAuthHandler>(
        "Training",
        options => { });

builder.Services.AddAuthorization();

builder.Services.AddSingleton<EnrollmentWorker>();

builder.Services.AddScoped<IEnrollmentService, EnrollmentService>();

builder.Services.AddScoped<IAuditService, AuditService>();

builder.Host.UseDefaultServiceProvider(options =>
{
    options.ValidateScopes = true;
    options.ValidateOnBuild = true;
});
builder.Services
    .AddOptions<PaymentOptions>()
    .Bind(builder.Configuration.GetSection("Payment"))
    .ValidateDataAnnotations()
    .ValidateOnStart();
    
var app = builder.Build();

app.UseExceptionHandler(errorApp =>
{
    errorApp.Run(async context =>
    {
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Response.ContentType = "application/json";

        var correlationId =
            context.Items["CorrelationId"]?.ToString();

        await context.Response.WriteAsJsonAsync(new
        {
            error = "An unexpected error occurred.",
            correlationId
        });
    });
});

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.Use(async (context, next) =>
{
    var correlationId = Guid.NewGuid().ToString("N")[..8];

    context.Items["CorrelationId"] = correlationId;

    context.Response.Headers["X-Correlation-Id"] = correlationId;

    var stopwatch = Stopwatch.StartNew();

    Console.WriteLine(
        $"[{correlationId}] --> Incoming {context.Request.Method} {context.Request.Path}");

    await next();

    stopwatch.Stop();

    Console.WriteLine(
        $"[{correlationId}] <-- Outgoing {context.Response.StatusCode} ({stopwatch.ElapsedMilliseconds} ms)");
});

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
