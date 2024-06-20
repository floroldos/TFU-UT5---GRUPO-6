using MySolidWebApi.Models;
using System.Text.Json;

namespace MySolidWebApi.Interfaces
{
    public interface IScoreService
    {
        SurfScore CalculateScore(JsonElement data);
    }
}
