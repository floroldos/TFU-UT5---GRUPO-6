using System.Linq;
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
            return performance.Puntaje.OrderBy(p => p.Calificacion).ToArray().Skip(1).Take(3).Average(p => p.Calificacion);
        }
    }
}