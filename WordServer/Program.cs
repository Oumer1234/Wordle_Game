using Microsoft.AspNetCore.Server.Kestrel.Core;
using WordServer.Services;

var builder = WebApplication.CreateBuilder(args);

// Add logging configuration
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Debug);

// Configure separate ports
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5293, o => o.Protocols = HttpProtocols.Http2); // HTTP
    options.ListenLocalhost(7164, o =>
    {
        o.Protocols = HttpProtocols.Http2;
        o.UseHttps(); // HTTPS
    });
});

// Add Grpc with logging
builder.Services.AddGrpc(options =>
{
    options.EnableDetailedErrors = true;
});

// Register DailyWordService as singleton to ensure it initializes once
builder.Services.AddSingleton<DailyWordService>();

var app = builder.Build();

// Force service initialization at startup
var wordService = app.Services.GetRequiredService<DailyWordService>();

app.MapGrpcService<DailyWordService>();
app.MapGet("/", () => "WordServer is running");
app.MapGet("/debug/word", () => wordService.GetDailyWord()); // Debug endpoint

app.Run();