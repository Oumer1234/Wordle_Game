using WordleGameServer.Services;
using WordServer.Protos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc(); // ✅ This registers core gRPC services

// Configure WordServer client
builder.Services.AddGrpcClient<DailyWord.DailyWordClient>(options =>
{
    options.Address = new Uri("https://localhost:5001"); // WordServer address
});

var app = builder.Build();

// Configure the HTTP request pipeline
app.MapGrpcService<DailyWordleService>(); // Requires AddGrpc() to be called first
app.MapGet("/", () => "Wordle Game Server is running. Use a gRPC client to access the service.");

app.Run();