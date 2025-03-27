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

            // ✅ Ensure the Data directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(_jsonPath));

            // ✅ Handle file not found without crashing the server
            if (!File.Exists(_jsonPath))
            {
                _logger.LogError("❌ `wordle.json` is missing! Expected at: {JsonPath}", _jsonPath);
                Console.WriteLine("⚠️ WARNING: `wordle.json` is missing. Word service will not function correctly.");
                return;
            }

            try
            {
                var json = File.ReadAllText(_jsonPath);
                _words = JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();

                if (_words.Count == 0)
                {
                    _logger.LogError("❌ `wordle.json` is empty or contains invalid data.");
                    Console.WriteLine("⚠️ WARNING: `wordle.json` is empty or invalid.");
                    return;
                }

                _isJsonLoaded = true;
                UpdateDailyWord();
                _logger.LogInformation("✅ `wordle.json` loaded successfully!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "❌ Error loading `wordle.json`.");
                Console.WriteLine("⚠️ WARNING: Failed to load `wordle.json`. Check file format.");
            }
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
            }
        }
    }
}
