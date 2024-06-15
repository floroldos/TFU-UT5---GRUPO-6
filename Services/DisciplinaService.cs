using MySolidWebApi.Interfaces;
using MySolidWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace MySolidWebApi.Services
{
    public class DisciplinaService : IDisciplinaService
    {
        private readonly Database<Disciplina> _database;
        private readonly Database<SurfScore> _scoreDatabase;

        public DisciplinaService()
        {
            _database = Database<Disciplina>.Instance;
            _scoreDatabase = Database<SurfScore>.Instance;
            // Pre-configurar la disciplina de Surf
            var surf = new Disciplina(
                "Surf",
                new SurfScoreService(), // Aquí utilizamos SurfScoreService
                new Modalidad { Nombre = "Olas", Categoria = "Acuática" }
            );
            _database.AddItem(surf);
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
                existingDisciplina.SistemaPuntuacion = disciplina.SistemaPuntuacion;
                existingDisciplina.Modalidad = disciplina.Modalidad;
            }
        }

        public void DeleteDisciplina(string nombre)
        {
            var disciplina = GetDisciplina(nombre);
            if (disciplina != null)
            {
                _database.GetItems().Remove(disciplina);
            }
        }

        public void AddPoints(string nombreDisciplina, int waveId, int surferId, double[] scores)
        {
            var disciplina = GetDisciplina(nombreDisciplina);
            if (disciplina != null)
            {
                var surfScoreService = disciplina.SistemaPuntuacion as SurfScoreService;
                surfScoreService?.CalculateAndSaveScore(waveId, surferId, scores);
            }
        }

        public SurfScore CalculateScore(string nombreDisciplina, int waveId, int surferId)
        {
            var disciplina = GetDisciplina(nombreDisciplina);
            if (disciplina != null)
            {
                var surfScoreService = disciplina.SistemaPuntuacion as SurfScoreService;
                return surfScoreService?.GetScore(waveId, surferId);
            }
            return null;
        }

        public void UpdateScore(string nombreDisciplina, int waveId, int surferId, double[] scores)
        {
            var disciplina = GetDisciplina(nombreDisciplina);
            if (disciplina != null)
            {
                var surfScoreService = disciplina.SistemaPuntuacion as SurfScoreService;
                surfScoreService?.UpdateScore(waveId, surferId, scores);
            }
        }

        public void DeleteScore(string nombreDisciplina, int waveId, int surferId)
        {
            var disciplina = GetDisciplina(nombreDisciplina);
            if (disciplina != null)
            {
                var surfScoreService = disciplina.SistemaPuntuacion as SurfScoreService;
                surfScoreService?.DeleteScore(waveId, surferId);
            }
        }
    }
}
