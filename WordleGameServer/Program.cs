using Microsoft.AspNetCore.Server.Kestrel.Core;
using WordServer.Protos;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddGrpc();
builder.Services.AddGrpcClient<DailyWord.DailyWordClient>(options =>
{
    options.Address = new Uri("http://localhost:5293"); // WordServer address
});

// Configure Kestrel
builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5031, o => o.Protocols = HttpProtocols.Http2);
});

var app = builder.Build();

// Middleware pipeline
app.MapGrpcService<DailyWordleService>();
app.MapGet("/", () => "WordleGameServer is running. Use gRPC client to connect.");

app.Run();