using MySolidWebApi.Models;
using System.Collections.Generic;

namespace MySolidWebApi.Interfaces
{
    public interface IDisciplinaService
    {
        Disciplina GetDisciplina(string nombre);
        IEnumerable<Disciplina> GetAllDisciplinas();
        void AddDisciplina(Disciplina disciplina);
        void UpdateDisciplina(string nombre, Disciplina disciplina);
        void DeleteDisciplina(string nombre);
        void AddPoints(string nombreDisciplina, int waveId, int surferId, double[] scores);
        SurfScore CalculateScore(string nombreDisciplina, int waveId, int surferId);
        void UpdateScore(string nombreDisciplina, int waveId, int surferId, double[] scores);
        void DeleteScore(string nombreDisciplina, int waveId, int surferId);
    }
}
