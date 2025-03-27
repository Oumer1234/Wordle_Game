using Grpc.Core;
using Grpc.Net.Client;
using WordleGameServer.Protos;
using WordServer.Protos;  // ✅ Using `DailyWordGrpc.cs` from `WordServer`

public class DailyWordleService : DailyWordle.DailyWordleBase
{
    private readonly DailyWord.DailyWordClient _wordClient;

    //public DailyWordleService()
    //{
    //    var channel = GrpcChannel.ForAddress("http://localhost:5101"); // Ensure WordServer is running
    //    _wordClient = new DailyWord.DailyWordClient(channel);
    //}

    public DailyWordleService(DailyWord.DailyWordClient wordClient)
    {
        _wordClient = wordClient;
    }

    public override async Task<StatsResponse> GetStats(StatsRequest request, ServerCallContext context)
    {
        // Dummy stats for now
        return await Task.FromResult(new StatsResponse
        {
            TotalPlayers = 100,
            WinPercentage = 55.5f,
            AverageGuesses = 4.2f
        });
    }
}
