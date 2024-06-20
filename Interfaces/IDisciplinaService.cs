using MySolidWebApi.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace MySolidWebApi.Interfaces
{
    public interface IDisciplinaService
    {
        Disciplina GetDisciplina(string nombre);
        IEnumerable<Disciplina> GetAllDisciplinas();
        void AddDisciplina(Disciplina disciplina);
        void UpdateDisciplina(string nombre, Disciplina disciplina);
        void DeleteDisciplina(string nombre);
        IScore CalculateAndSaveScore(string nombre, JsonElement data);
        IScore GetScore(string nombre, JsonElement data);
        IEnumerable<IScore> GetAllScores();
        void UpdateScore(string nombre, JsonElement data);
        void DeleteScore(string nombre, JsonElement data);
        void AddPerformance(JsonElement body);
        IEnumerable<Performance> getRankingDisciplina(string disciplinaName);

        public IEnumerable<Performance> GetAllPerformances();

    }
}
