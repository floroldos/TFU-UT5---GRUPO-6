using MySolidWebApi.Interfaces;
using MySolidWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;


namespace MySolidWebApi.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly Database<Disciplina> _database;
        private readonly Database<SurfScore> _scoreDatabase;
        private readonly Database<Performance> _performanceDatabase;

        private Handler handler1 = new HandlerHalterofilia();
        private Handler handler2 = new HandlerSurf();
        private Handler handler3 = new HandlerNatacion();
        public DisciplinaService()
        {
            _database = Database<Disciplina>.Instance;
            _scoreDatabase = Database<SurfScore>.Instance;
            _performanceDatabase = Database<Performance>.Instance;
            var surf = new Disciplina(
               "Surf",
               new Modalidad("Olas", "Acuática")
           );

            var halterofilia = new Disciplina(
                "Halterofilia",
                new Modalidad("Masculino", "")
            );

            var natacion = new Disciplina(
               "Natación",
               new Modalidad("Libre", "100m masculino")
           );

            _database.AddItem(surf);
            _database.AddItem(natacion);
            _database.AddItem(halterofilia);

            handler1.setNext(handler2);
            handler2.setNext(handler3);

        }

        public Disciplina GetDisciplina(string nombre)
        {
            return _database.GetItems().FirstOrDefault(d => d.Nombre == nombre);
        }

        public IEnumerable<Disciplina> GetAllDisciplinas()
        {
            return _database.GetItems();
        }

        public void AddDisciplina(Disciplina disciplina)
        {
            _database.AddItem(disciplina);
        }

        public void UpdateDisciplina(string nombre, Disciplina disciplina)
        {
            var existingDisciplina = GetDisciplina(nombre);
            if (existingDisciplina != null)
            {
                existingDisciplina.Nombre = disciplina.Nombre;
                existingDisciplina.ScoreService = disciplina.ScoreService;
                existingDisciplina.Modalidad = disciplina.Modalidad;
            }
        }

        public void DeleteDisciplina(string nombre)
        {
            var disciplina = GetDisciplina(nombre);
            if (disciplina != null)
            {
                _database.RemoveItem(disciplina);
            }
        }

        public IScore CalculateAndSaveScore(string nombre, JsonElement data)
        {
            var disciplina = GetDisciplina(nombre);
            if (disciplina != null)
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

                var waveId = waveIdElement.GetInt32();
                var surferId = surferIdElement.GetInt32();
                var rawScores = scoresElement.EnumerateArray().Select(e => e.GetDouble()).ToArray();
                var puntaje = rawScores.Select(score => new Puntaje(score)).ToArray();

                string concatenatedString = $"{waveId}.{surferId}";
                float.TryParse(concatenatedString, out float concatenatedFloat);

                var score = new SurfScoreService().CalculateScore(data);

                var performance = new Performance(concatenatedFloat, DateTime.Now, disciplina, new Equipo("", [new Atleta("nombre", 50, Sexo.Masculino)]), puntaje);
                _scoreDatabase.AddItem(score);

                return score;
            }
            throw new ArgumentException($"Disciplina with name '{nombre}' not found.");
        }

        public IScore GetScore(string nombre, JsonElement data)
        {
            var disciplina = GetDisciplina(nombre);
            if (disciplina != null)
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

                var waveId = waveIdElement.GetInt32();
                var surferId = surferIdElement.GetInt32();

                return _scoreDatabase.GetItems().FirstOrDefault(s => s.WaveId == waveId && s.SurferId == surferId);
            }
            throw new ArgumentException($"Disciplina with name '{nombre}' not found.");
        }

        public IEnumerable<IScore> GetAllScores()
        {
            return _scoreDatabase.GetItems();
        }

        public void UpdateScore(string nombre, JsonElement data)
        {
            var disciplina = GetDisciplina(nombre);
            if (disciplina != null)
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

                var waveId = waveIdElement.GetInt32();
                var surferId = surferIdElement.GetInt32();
                var rawScores = scoresElement.EnumerateArray().Select(e => e.GetDouble()).ToArray();
                var puntaje = rawScores.Select(score => new Puntaje(score)).ToArray();

                string concatenatedString = $"{waveId}.{surferId}";
                float.TryParse(concatenatedString, out float concatenatedFloat);

                var score = new SurfScoreService().CalculateScore(data);
                var performance = new Performance(concatenatedFloat, DateTime.Now, disciplina, new Equipo("", [new Atleta("nombre", 50, Sexo.Masculino)]), puntaje);

                var element = _scoreDatabase.GetItems().FirstOrDefault(s => s.WaveId == waveId && s.SurferId == surferId);

                if (element != null)
                {
                    element.FinalScore = score.FinalScore;
                    element.Scores = score.Scores;
                    element.SurferId = element.SurferId;
                    element.WaveId = element.WaveId;
                }
            }
            throw new ArgumentException($"Disciplina with name '{nombre}' not found.");
        }

        public void DeleteScore(string nombre, JsonElement data)
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

            var waveId = waveIdElement.GetInt32();
            var surferId = surferIdElement.GetInt32();
            var score = _scoreDatabase.GetItems().FirstOrDefault(s => s.WaveId == waveId && s.SurferId == surferId);
            if (score != null)
            {
                _scoreDatabase.RemoveItem(score);
            }
        }

        // NUEVOS ENDPOINTS
        public void AddPerformance(JsonElement body)
        {
            Performance performance;
            try
            {

                /* var options = new JsonSerializerOptions
                                {
                                    PropertyNameCaseInsensitive = true
                                };*/
                performance = JsonSerializer.Deserialize<Performance>(body.GetRawText());
                if (performance.Disciplina == null)
                {
                    throw new ArgumentException("Disciplina not found");
                }
                var disciplinaExists = _database.GetItems().FirstOrDefault(d => d.Nombre == performance.Disciplina.Nombre);
                if (disciplinaExists == null)
                {
                    throw new ArgumentException("Disciplina not found");
                }
                performance.Disciplina = disciplinaExists;
                if (performance.Puntaje.Length == 0)
                {
                    throw new ArgumentException("Puntaje not found");
                }
                if (performance.Equipo.Atletas.Length == 0)
                {
                    throw new ArgumentException("Equipo/Atletas not found");
                }

            }
            catch (JsonException)
            {
                throw new JsonException();
            }

            _performanceDatabase.AddItem(performance);

        }

        public IEnumerable<Performance> getRankingDisciplina(String nombreDisciplina)
        {
            var disciplinaExists = _database.GetItems().Any(d => d.Nombre == nombreDisciplina);
            if (!disciplinaExists)
            {
                throw new ArgumentException("Disciplina not found");
            }

            IEnumerable<Performance> performances = _performanceDatabase.GetItems().Where(p => p.Disciplina.Nombre == nombreDisciplina);
            foreach (var p in performances)
            {
                p.puntajeObtenido = handler1.handle(p);
            }
            return performances.OrderByDescending(p => p.puntajeObtenido);
        }

        public IEnumerable<Performance> GetAllPerformances()
        {
            return _performanceDatabase.GetItems();
        }

    }
}
