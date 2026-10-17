using DocumentPlatform.Api.Middleware;
using DocumentPlatform.Api.Options;
using DocumentPlatform.Api.Services;
using Serilog;
using Swashbuckle.AspNetCore;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Host.UseSerilog((context, services, configuration) => configuration
        .ReadFrom.Configuration(context.Configuration)
        .ReadFrom.Services(services)
        .Enrich.FromLogContext()
        .WriteTo.Console()
        .WriteTo.Seq(context.Configuration["Seq:ServerUrl"]!));

    // Add services to the container.

    builder.Services.AddControllers();
    builder.Services.AddScoped<IDocumentService, DocumentService>();
    builder.Services.AddTransient<TransientLifetimeService>();
    builder.Services.AddScoped<ScopedLifetimeService>();
    builder.Services.AddSingleton<SingletonLifetimeService>();
    builder.Services.Configure<DocumentOptions>(builder.Configuration.GetSection("DocumentOptions"));
    builder.Services.AddProblemDetails();
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
    builder.Services.AddOpenApi();

    var app = builder.Build();

    app.UseSerilogRequestLogging();

    app.UseExceptionHandler();

    app.UseMiddleware<RequestTimingMiddleware>();
    app.UseMiddleware<ShortCircuitMiddleware>();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/openapi/v1.json", "v1");
        });
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
    throw;
}
finally
{
    Log.CloseAndFlush();
}
