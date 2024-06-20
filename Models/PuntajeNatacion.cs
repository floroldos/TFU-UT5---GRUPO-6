using MySolidWebApi.Interfaces;
using MySolidWebApi.Services;
namespace MySolidWebApi.Models
{

    public class PuntajeNatacion : IStrategyPuntaje
    {

        public double calculateScore(Performance performance)
        {
            // poner como puntajeObtenido el tiempo
            if (performance.Puntaje == null)
            {
                throw new Exception("Le falta puntaje a la performance.");
            }

            return performance.Puntaje[0].Calificacion;
        }
    }
}