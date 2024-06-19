using MySolidWebApi.Models;
using System.Collections.Generic;
using System.Text.Json;

namespace MySolidWebApi.Interfaces
{
    public interface IScoreService
    {
        SurfScore CalculateAndSaveScore(JsonElement data);
        SurfScore GetScore(JsonElement data);
        IEnumerable<SurfScore> GetAllScores();
        void UpdateScore(JsonElement data);
        void DeleteScore(JsonElement data);
    }
}
