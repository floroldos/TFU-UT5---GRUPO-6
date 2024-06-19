using MySolidWebApi.Models;
namespace MySolidWebApi.Interfaces
{

    public interface IStrategyPuntaje
    {
        public double calculateScore(Performance performance);

    }
}