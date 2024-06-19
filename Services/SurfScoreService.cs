using MySolidWebApi.Interfaces;
using MySolidWebApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace MySolidWebApi.Services
{
    public class SurfScoreService : IScoreService
    {
        private readonly Database<SurfScore> _database;

        public SurfScoreService()
        {
            _database = Database<SurfScore>.Instance;
        }

        public SurfScore CalculateAndSaveScore(JsonElement data)
        {
            // Check if 'Scores' property exists and has 5 elements
            if (!data.TryGetProperty("Scores", out JsonElement scoresElement) || 
                scoresElement.ValueKind != JsonValueKind.Array ||
                scoresElement.GetArrayLength() != 5)
            {
                throw new ArgumentException("Five scores are required.");
            }

            // Check if 'WaveId' property exists
            if (!data.TryGetProperty("WaveId", out JsonElement waveIdElement) || 
                waveIdElement.ValueKind != JsonValueKind.Number)
            {
                throw new ArgumentException("WaveId is required and must be a number.");
            }

            // Check if 'SurferId' property exists
            if (!data.TryGetProperty("SurferId", out JsonElement surferIdElement) || 
                surferIdElement.ValueKind != JsonValueKind.Number)
            {
                throw new ArgumentException("SurferId is required and must be a number.");
            }

            // Extract values from the request
            var waveId = data.GetProperty("WaveId").GetInt32();
            var surferId = data.GetProperty("SurferId").GetInt32();
            var scores = scoresElement.EnumerateArray().Select(e => e.GetDouble()).ToArray();

            var orderedScores = scores.OrderBy(s => s).ToArray();
            var finalScore = orderedScores.Skip(1).Take(3).Average();

            var surfScore = new SurfScore
            {
                WaveId = waveId,
                SurferId = surferId,
                Scores = scores,
                FinalScore = finalScore
            };

            _database.AddItem(surfScore);
            return surfScore;
        }

        public SurfScore GetScore(JsonElement data)
        {
            // Check if 'WaveId' property exists
            if (!data.TryGetProperty("WaveId", out JsonElement waveIdElement) || 
                waveIdElement.ValueKind != JsonValueKind.Number)
            {
                throw new ArgumentException("WaveId is required and must be a number.");
            }

            // Check if 'SurferId' property exists
            if (!data.TryGetProperty("SurferId", out JsonElement surferIdElement) || 
                surferIdElement.ValueKind != JsonValueKind.Number)
            {
                throw new ArgumentException("SurferId is required and must be a number.");
            }

            // Extract values from the request
            var waveId = data.GetProperty("WaveId").GetInt32();
            var surferId = data.GetProperty("SurferId").GetInt32();

            return _database.GetItems().FirstOrDefault(s => s.WaveId == waveId && s.SurferId == surferId);
        }

        public IEnumerable<SurfScore> GetAllScores()
        {
            return _database.GetItems();
        }

        public void UpdateScore(JsonElement data)
        {
            // Check if 'Scores' property exists and has 5 elements
            if (!data.TryGetProperty("Scores", out JsonElement scoresElement) || 
                scoresElement.ValueKind != JsonValueKind.Array ||
                scoresElement.GetArrayLength() != 5)
            {
                throw new ArgumentException("Five scores are required.");
            }

            // Extract values from the request
            var scores = scoresElement.EnumerateArray().Select(e => e.GetDouble()).ToArray();

            var existingScore = GetScore(data);
            if (existingScore != null)
            {
                existingScore.Scores = scores;
                var orderedScores = scores.OrderBy(s => s).ToArray();
                existingScore.FinalScore = orderedScores.Skip(1).Take(3).Average();
            }
        }

        public void DeleteScore(JsonElement data)
        {
            var score = GetScore(data);
            if (score != null)
            {
                _database.GetItems().Remove(score);
            }
        }
    }
}
