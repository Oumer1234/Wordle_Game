using Grpc.Core;
using Grpc.Net.Client;
using WordleGameServer.Protos;

try
{
    Console.WriteLine("🔵 Connecting to server...");

    // Configure channel with timeout
    var channel = GrpcChannel.ForAddress("http://localhost:5031", new GrpcChannelOptions
    {
        HttpHandler = new SocketsHttpHandler
        {
            PooledConnectionIdleTimeout = Timeout.InfiniteTimeSpan,
            KeepAlivePingDelay = TimeSpan.FromSeconds(60)
        }
    });

    var client = new DailyWordle.DailyWordleClient(channel);
    Console.WriteLine("🟢 Connected! Let's play Wordle!\n");

    // Create the streaming call
    using var call = client.Play();

    // Response handler
    var readTask = Task.Run(async () =>
    {
        try
        {
            await foreach (var response in call.ResponseStream.ReadAllAsync())
            {
                if (response.Result == "invalid")
                {
                    Console.WriteLine("❌ Not a valid word");
                    return;
                }

                Console.WriteLine($"\n📊 Result: {response.Result}");
                Console.WriteLine($"✅ Correct: {string.Join("", response.IncludedLetters)}");
                Console.WriteLine($"❌ Wrong: {string.Join("", response.ExcludedLetters)}");
                Console.WriteLine($"💡 Guesses left: {response.GuessesRemaining}");

                if (response.GameOver)
                {
                    Console.WriteLine(response.GameWon ? "🎉 You won!" : "💀 Game over!");
                    return;
                }
            }
        }
        catch (RpcException ex)
        {
            Console.WriteLine($"\n🔴 Server error: {ex.Status.Detail}");
        }
    });

    // Game loop
    while (true)
    {
        Console.Write("\n⌨️ Your guess (5 letters): ");
        var guess = Console.ReadLine()?.Trim().ToLower();

        if (guess == "quit") break;
        if (string.IsNullOrEmpty(guess)) continue;

        try
        {
            await call.RequestStream.WriteAsync(new GuessRequest { Guess = guess });
        }
        catch (RpcException ex)
        {
            Console.WriteLine($"\n🔴 Failed to send guess: {ex.Status.Detail}");
            break;
        }

        if (readTask.IsCompleted) break;
    }

    // Clean shutdown
    await call.RequestStream.CompleteAsync();
    await readTask;
}
catch (Exception ex)
{
    Console.WriteLine($"\n🔴 Fatal error: {ex.Message}");
}
finally
{
    Console.WriteLine("\nPress any key to exit...");
    Console.ReadKey();
}