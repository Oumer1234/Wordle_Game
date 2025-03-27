using System;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using WordleGameServer.Protos;

class Program
{
    static async Task Main()
    {
        Console.WriteLine("🔵 Connecting to WordleGameServer...");
        using var channel = GrpcChannel.ForAddress("http://localhost:5001"); // Update if your server runs on a different port
        var client = new DailyWordle.DailyWordleClient(channel);

        Console.WriteLine("✅ Connected! Let's play Wordle!");

        using var call = client.Play();
        while (true)
        {
            Console.Write("\nEnter your guess: ");
            string guess = Console.ReadLine() ?? "";

            if (string.IsNullOrWhiteSpace(guess))
            {
                Console.WriteLine("❌ Invalid input. Try again.");
                continue;
            }

            await call.RequestStream.WriteAsync(new GuessRequest { Guess = guess });

            if (await call.ResponseStream.MoveNext())
            {
                var response = call.ResponseStream.Current;
                Console.WriteLine($"🟡 Result: {response.Result}");
                Console.WriteLine($"📌 Remaining guesses: {response.GuessesRemaining}");

                if (response.GameWon)
                {
                    Console.WriteLine("🎉 You won! 🎉");
                    break;
                }
                if (response.GameOver)
                {
                    Console.WriteLine("💀 Game over! Try again tomorrow.");
                    break;
                }
            }
        }
        await call.RequestStream.CompleteAsync();

        Console.WriteLine("\n📊 Fetching game stats...");
        var stats = await client.GetStatsAsync(new StatsRequest());
        Console.WriteLine($"🧑‍🤝‍🧑 Total Players: {stats.TotalPlayers}");
        Console.WriteLine($"🏆 Win Percentage: {stats.WinPercentage}%");
        Console.WriteLine($"⌛ Average Guesses: {stats.AverageGuesses}");
    }
}
