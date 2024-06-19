using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{

    public class PuntajeSurf : IStrategyPuntaje
    {
        public double calculateScore(Performance performance)
        {
            if (performance.Puntaje == null)
            {
                throw new Exception("Le falta puntaje a la performance.");
            }
            return 0.0;
        }

    }
}