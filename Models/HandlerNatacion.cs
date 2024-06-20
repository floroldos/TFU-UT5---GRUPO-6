using MySolidWebApi.Models;
namespace MySolidWebApi.Models
{
    public class HandlerNatacion : DisciplinaHandler
    {
        public override double handle(Performance performance)
        {
            Console.WriteLine("NATACIÓN");
            if (performance.Disciplina.Nombre == "Natación")
            {
                PuntajeNatacion puntajeNatacion = new PuntajeNatacion();

                double score = puntajeNatacion.calculateScore(performance);
                return score;
            }
            else if (next != null)
            {
                return next.handle(performance);
            }
            return -1.0;
        }
    }

}