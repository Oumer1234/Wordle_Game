using Grpc.Core;
using Grpc.Net.Client;
using WordleGameServer.Protos;
using WordServer.Protos;  // ✅ Ensure this is correctly referenced

public class DailyWordleService : DailyWordle.DailyWordleBase
{
    private readonly DailyWord.DailyWordClient _wordClient;

    public DailyWordleService(DailyWord.DailyWordClient wordClient) // ✅ Inject dependency
    {
        _wordClient = wordClient ?? throw new ArgumentNullException(nameof(wordClient));
    }

    public override async Task<StatsResponse> GetStats(StatsRequest request, ServerCallContext context)
    {
        return await Task.FromResult(new StatsResponse
        {
            TotalPlayers = 100,
            WinPercentage = 55.5f,
            AverageGuesses = 4.2f
        });
    }




}
