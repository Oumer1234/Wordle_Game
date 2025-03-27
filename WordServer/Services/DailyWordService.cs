using System;
using System.IO;
using System.Text.Json;
using System.Collections.Generic;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using WordServer.Protos;

namespace WordServer.Services
{
    public class DailyWordService : DailyWord.DailyWordBase
    {
        private readonly List<string> _words = new();
        private string _dailyWord = "";
        private DateTime _lastUpdated = DateTime.MinValue;
        private static readonly string _jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "wordle.json");
        private readonly ILogger<DailyWordService> _logger;
        private bool _isJsonLoaded = false;

        public DailyWordService(ILogger<DailyWordService> logger)
        {
            _logger = logger;
            Console.WriteLine("🟢 DailyWordService is starting...");
            _logger.LogInformation("DailyWordService is starting...");

            // ✅ Ensure the Data directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(_jsonPath));
            _logger.LogInformation($"Checking for wordle.json at: {_jsonPath}");

            // ✅ Check if `wordle.json` exists
            if (!File.Exists(_jsonPath))
            {
                var errorMsg = "❌ `wordle.json` is missing!";
                Console.WriteLine(errorMsg);
                _logger.LogError(errorMsg);
                return;
            }

            try
            {
                _logger.LogInformation("📂 Loading `wordle.json`...");
                var json = File.ReadAllText(_jsonPath);
                _words = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

                if (_words.Count == 0)
                {
                    var warningMsg = "⚠️ `wordle.json` is empty!";
                    Console.WriteLine(warningMsg);
                    _logger.LogWarning(warningMsg);
                    return;
                }

                _isJsonLoaded = true;
                var successMsg = "✅ `wordle.json` loaded successfully!";
                Console.WriteLine(successMsg);
                _logger.LogInformation(successMsg);

                UpdateDailyWord();
                var dailyWordMsg = $"🔍 Daily Word: {_dailyWord}";
                Console.WriteLine(dailyWordMsg);
                _logger.LogInformation(dailyWordMsg);
            }
            catch (Exception ex)
            {
                var errorMsg = $"❌ Error loading `wordle.json`: {ex.Message}";
                Console.WriteLine(errorMsg);
                _logger.LogError(ex, errorMsg);
            }
        }
        public string GetDailyWord()
        {
            if (!_isJsonLoaded)
            {
                _logger.LogWarning("Word list not loaded - cannot get daily word");
                return "ERROR: Word list not loaded";
            }

            UpdateDailyWord(); // Ensure we have the current word
            return _dailyWord;
        }
        public override Task<WordResponse> GetWord(WordRequest request, ServerCallContext context)
        {
            if (!_isJsonLoaded)
            {
                return Task.FromResult(new WordResponse { Word = "⚠️ ERROR: `wordle.json` is missing or invalid!" });
            }

            UpdateDailyWord();
            return Task.FromResult(new WordResponse { Word = _dailyWord });
        }

        public override Task<WordValidationResponse> ValidateWord(WordValidationRequest request, ServerCallContext context)
        {
            if (!_isJsonLoaded)
            {
                return Task.FromResult(new WordValidationResponse { IsValid = false });
            }

            return Task.FromResult(new WordValidationResponse
            {
                IsValid = _words.Contains(request.Word.ToLower())
            });
        }

        private void UpdateDailyWord()
        {
            if (!_isJsonLoaded) return;

            var today = DateTime.Today;
            if (_lastUpdated < today)
            {
                var random = new Random();
                _dailyWord = _words[random.Next(_words.Count)];
                _lastUpdated = today;
                Console.WriteLine($"🔍 Daily Word: {_dailyWord}"); // ✅ Log the daily word
            }
        }

    }
}
