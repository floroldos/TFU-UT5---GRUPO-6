using MySolidWebApi.Models;
using System.Collections.Generic;

namespace MySolidWebApi.Interfaces
{
    public interface ISurfScoreService
    {
        SurfScore CalculateAndSaveScore(int waveId, int surferId, double[] scores);
        SurfScore GetScore(int waveId, int surferId);
        IEnumerable<SurfScore> GetAllScores();
        void UpdateScore(int waveId, int surferId, double[] scores);
        void DeleteScore(int waveId, int surferId);
    }
}
