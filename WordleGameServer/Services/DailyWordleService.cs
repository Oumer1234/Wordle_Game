using Grpc.Core;
using Grpc.Net.Client;
using System.Collections.Concurrent;
using System.Text.Json;
using WordleGameServer.Protos;
using WordServer.Protos;

public class DailyWordleService : DailyWordle.DailyWordleBase
{
    private readonly DailyWord.DailyWordClient _wordClient;
    private static readonly ConcurrentDictionary<string, GameStats> _dailyStats = new();
    private static readonly string _statsFilePath = "wordle_stats.json";
    private static readonly Mutex _statsMutex = new();
    private string _currentDailyWord = "";
    private DateTime _wordLastUpdated = DateTime.MinValue;

    public DailyWordleService(DailyWord.DailyWordClient wordClient)
    {
        _wordClient = wordClient ?? throw new ArgumentNullException(nameof(wordClient));
        LoadStats();
    }

    public override async Task Play(IAsyncStreamReader<GuessRequest> requestStream,
        IServerStreamWriter<GuessResponse> responseStream, ServerCallContext context)
    {
        try
        {
            // Get today's word
            await UpdateDailyWord();
            var targetWord = _currentDailyWord.ToLower();
            var gameWon = false;
            var guessesUsed = 0;
            var maxGuesses = 6;
            var includedLetters = new HashSet<char>();
            var excludedLetters = new HashSet<char>();
            var today = DateTime.Today.ToString("yyyy-MM-dd");

            await foreach (var guessRequest in requestStream.ReadAllAsync())
            {
                var guess = guessRequest.Guess?.ToLower() ?? "";

                // Validate input
                if (guess.Length != 5)
                {
                    await responseStream.WriteAsync(new GuessResponse
                    {
                        Result = "invalid_length",
                        GameOver = false
                    });
                    continue;
                }

                // Validate word exists
                var validation = await _wordClient.ValidateWordAsync(new WordValidationRequest { Word = guess });
                if (!validation.IsValid)
                {
                    await responseStream.WriteAsync(new GuessResponse
                    {
                        Result = "invalid_word",
                        GameOver = false
                    });
                    continue;
                }

                // Process valid guess
                guessesUsed++;
                var result = EvaluateGuess(guess, targetWord, includedLetters, excludedLetters);

                // Check for win
                gameWon = guess == targetWord;

                // Prepare response
                await responseStream.WriteAsync(new GuessResponse
                {
                    Result = result,
                    IncludedLetters = { includedLetters.Select(c => c.ToString()) },
                    ExcludedLetters = { excludedLetters.Select(c => c.ToString()) },
                    AvailableLetters = { GetAvailableLetters(includedLetters, excludedLetters) },
                    GameOver = gameWon || guessesUsed >= maxGuesses,
                    GameWon = gameWon,
                    GuessesRemaining = maxGuesses - guessesUsed
                });

                if (gameWon || guessesUsed >= maxGuesses)
                {
                    UpdateStatistics(today, gameWon, guessesUsed);
                    break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in Play: {ex.Message}");
            throw;
        }
    }

    public override async Task<StatsResponse> GetStats(StatsRequest request, ServerCallContext context)
    {
        await UpdateDailyWord();
        var today = DateTime.Today.ToString("yyyy-MM-dd");
        _dailyStats.TryGetValue(today, out var stats);

        return new StatsResponse
        {
            TotalPlayers = stats?.TotalPlayers ?? 0,
            WinPercentage = stats?.TotalPlayers > 0 ? (float)stats.Winners / stats.TotalPlayers * 100 : 0,
            AverageGuesses = stats?.Winners > 0 ? (float)stats.TotalGuesses / stats.Winners : 0,
            CurrentWord = _currentDailyWord
        };
    }

    private async Task UpdateDailyWord()
    {
        if (_wordLastUpdated.Date < DateTime.Today)
        {
            var response = await _wordClient.GetWordAsync(new WordRequest());
            _currentDailyWord = response.Word;
            _wordLastUpdated = DateTime.Now;
            Console.WriteLine($"Daily word updated to: {_currentDailyWord}");
        }
    }

    private string EvaluateGuess(string guess, string targetWord, HashSet<char> includedLetters, HashSet<char> excludedLetters)
    {
        var result = new char[5];
        var tempTarget = targetWord.ToCharArray();
        var tempGuess = guess.ToCharArray();

        // First pass: exact matches
        for (int i = 0; i < 5; i++)
        {
            if (tempGuess[i] == tempTarget[i])
            {
                result[i] = '*';
                includedLetters.Add(tempGuess[i]);
                tempTarget[i] = ' ';
                tempGuess[i] = '_';
            }
        }

        // Second pass: correct letters in wrong position
        for (int i = 0; i < 5; i++)
        {
            if (tempGuess[i] == '_') continue;

            var indexInTarget = Array.IndexOf(tempTarget, tempGuess[i]);
            if (indexInTarget >= 0)
            {
                result[i] = '?';
                includedLetters.Add(tempGuess[i]);
                tempTarget[indexInTarget] = ' ';
            }
            else
            {
                result[i] = 'x';
                excludedLetters.Add(tempGuess[i]);
            }
        }

        return new string(result);
    }

    private IEnumerable<string> GetAvailableLetters(HashSet<char> included, HashSet<char> excluded)
    {
        return "abcdefghijklmnopqrstuvwxyz"
            .Where(c => !included.Contains(c) && !excluded.Contains(c))
            .Select(c => c.ToString());
    }

    private void UpdateStatistics(string date, bool won, int guessesUsed)
    {
        _statsMutex.WaitOne();
        try
        {
            var stats = _dailyStats.GetOrAdd(date, new GameStats());
            stats.TotalPlayers++;

            if (won)
            {
                stats.Winners++;
                stats.TotalGuesses += guessesUsed;
            }

            SaveStats();
        }
        finally
        {
            _statsMutex.ReleaseMutex();
        }
    }

    private void LoadStats()
    {
        if (!File.Exists(_statsFilePath)) return;

        _statsMutex.WaitOne();
        try
        {
            var json = File.ReadAllText(_statsFilePath);
            var loadedStats = JsonSerializer.Deserialize<Dictionary<string, GameStats>>(json);
            if (loadedStats != null)
            {
                foreach (var kvp in loadedStats)
                {
                    _dailyStats[kvp.Key] = kvp.Value;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading stats: {ex.Message}");
        }
        finally
        {
            _statsMutex.ReleaseMutex();
        }
    }

    private void SaveStats()
    {
        _statsMutex.WaitOne();
        try
        {
            var json = JsonSerializer.Serialize(_dailyStats);
            File.WriteAllText(_statsFilePath, json);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving stats: {ex.Message}");
        }
        finally
        {
            _statsMutex.ReleaseMutex();
        }
    }

    private class GameStats
    {
        public int TotalPlayers { get; set; }
        public int Winners { get; set; }
        public int TotalGuesses { get; set; }
    }
}