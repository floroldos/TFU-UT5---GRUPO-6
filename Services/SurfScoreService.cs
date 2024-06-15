using MySolidWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MySolidWebApi.Services
{
    public class SurfScoreService : SistemaPuntuacion
    {
        private readonly Database<SurfScore> _database;

        public SurfScoreService()
        {
            _database = Database<SurfScore>.Instance;
            Reglas = new string[]
            {
                "Evaluar la velocidad, potencia y fluidez de las maniobras.",
                "Puntuación basada en la dificultad y el compromiso de las maniobras.",
                "Innovación y progresión en las maniobras ejecutadas.",
                "Diversidad y combinación de maniobras mayores.",
                "Finalización de la ola de manera limpia y controlada."
            };
        }

        public override double CalculateFinalScore(double[] scores)
        {
            if (scores == null || scores.Length != 5)
            {
                throw new ArgumentException("Five scores are required.");
            }

            var orderedScores = scores.OrderBy(s => s).ToArray();
            return orderedScores.Skip(1).Take(3).Average();
        }

        public SurfScore CalculateAndSaveScore(int waveId, int surferId, double[] scores)
        {
            var finalScore = CalculateFinalScore(scores);

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

        public SurfScore GetScore(int waveId, int surferId)
        {
            return _database.GetItems().FirstOrDefault(s => s.WaveId == waveId && s.SurferId == surferId);
        }

        public IEnumerable<SurfScore> GetAllScores()
        {
            return _database.GetItems();
        }

        public void UpdateScore(int waveId, int surferId, double[] scores)
        {
            var existingScore = GetScore(waveId, surferId);
            if (existingScore != null)
            {
                existingScore.Scores = scores;
                existingScore.FinalScore = CalculateFinalScore(scores);
            }
        }

        public void DeleteScore(int waveId, int surferId)
        {
            var score = GetScore(waveId, surferId);
            if (score != null)
            {
                _database.GetItems().Remove(score);
            }
        }
    }
}
