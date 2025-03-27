using Microsoft.AspNetCore.Server.Kestrel.Core;
using WordServer.Services;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddGrpc();

var app = builder.Build();

app.MapGrpcService<DailyWordService>();
app.MapGet("/", () => "WordServer is running");

app.Run();