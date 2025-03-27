using Grpc.Core;
using Grpc.Net.Client;
using WordleGameServer.Protos;

try
{
    Console.WriteLine("🔵 Connecting to game server...");

    // Only connect to WordleGameServer
    var channel = GrpcChannel.ForAddress("http://localhost:5031");
    var client = new DailyWordle.DailyWordleClient(channel);

    Console.WriteLine("🟢 Connected! Let's play Wordle!\n");

    using var call = client.Play();

    // Response handler
    var readTask = Task.Run(async () =>
    {
        try
        {
            await foreach (var response in call.ResponseStream.ReadAllAsync())
            {
                Console.Clear();
                Console.WriteLine($"WORDLE - Guesses left: {response.GuessesRemaining}\n");

                // Display result pattern
                Console.WriteLine($"Result: {response.Result}");

                // Display keyboard status
                Console.WriteLine("\nIncluded letters: " + string.Join("", response.IncludedLetters));
                Console.WriteLine("Excluded letters: " + string.Join("", response.ExcludedLetters));
                Console.WriteLine("Available letters: " + string.Join("", response.AvailableLetters));

                if (response.GameOver)
                {
                    Console.WriteLine(response.GameWon ? "\n🎉 You won!" : "\n💀 Game over!");

                    if (response.GameWon)
                    {
                        Console.WriteLine($"You guessed it in {6 - response.GuessesRemaining} tries!");
                    }
                    else
                    {
                        // Get the word through stats endpoint (proper way)
                        Console.WriteLine($"The word was: {(await client.GetStatsAsync(new StatsRequest())).CurrentWord}");
                    }

                    // Show statistics
                    var stats = await client.GetStatsAsync(new StatsRequest());
                    Console.WriteLine("\nStatistics:");
                    Console.WriteLine($"Total players today: {stats.TotalPlayers}");
                    Console.WriteLine($"Win percentage: {stats.WinPercentage:F1}%");
                    Console.WriteLine($"Average guesses (winners): {stats.AverageGuesses:F1}");

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
        Console.Write("\n⌨️ Your guess (5 letters, 'quit' to exit): ");
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