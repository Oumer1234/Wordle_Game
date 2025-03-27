using Microsoft.AspNetCore.Server.Kestrel.Core;
using WordServer.Protos;

var builder = WebApplication.CreateBuilder(args);

// ✅ Enable detailed logging
builder.Logging.SetMinimumLevel(LogLevel.Debug);
builder.Logging.AddConsole();

builder.Services.AddGrpc();
builder.Services.AddGrpcClient<DailyWord.DailyWordClient>(options =>
{
    options.Address = new Uri("http://localhost:5293"); // ✅ Ensure this matches WordServer
});

// Configure Kestrel
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5031, o => o.Protocols = HttpProtocols.Http2);
});

var app = builder.Build();

// ✅ Log all incoming requests
app.Use(async (context, next) =>
{
    Console.WriteLine($"🟢 Received request: {context.Request.Method} {context.Request.Path}");
    await next();
});

app.MapGrpcService<DailyWordleService>();
app.MapGet("/", () => "WordleGameServer is running. Use gRPC client to connect.");

app.Run();
