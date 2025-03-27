using Grpc.Core;
using System.Text.Json;
using WordServer.Protos;

namespace WordServer.Services;

public class DailyWordService : DailyWord.DailyWordBase
{
    private readonly List<string> _words;
    private string _dailyWord = "";
    private DateTime _lastUpdated = DateTime.MinValue;

    public DailyWordService()
    {
        // Create Data directory if it doesn't exist
        Directory.CreateDirectory("Data");

        // Initialize word list
        var json = File.ReadAllText("Data/wordle.json");
        _words = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
        UpdateDailyWord();
    }

    public override Task<WordResponse> GetWord(WordRequest request, ServerCallContext context)
    {
        UpdateDailyWord();
        return Task.FromResult(new WordResponse { Word = _dailyWord });
    }

    public override Task<WordValidationResponse> ValidateWord(WordValidationRequest request, ServerCallContext context)
    {
        return Task.FromResult(new WordValidationResponse
        {
            IsValid = _words.Contains(request.Word.ToLower())
        });
    }

    private void UpdateDailyWord()
    {
        var today = DateTime.Today;
        if (_lastUpdated < today)
        {
            var random = new Random();
            _dailyWord = _words[random.Next(_words.Count)];
            _lastUpdated = today;
        }
    }
}