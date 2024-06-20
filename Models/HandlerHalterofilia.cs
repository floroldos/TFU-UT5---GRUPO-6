using MySolidWebApi.Models;
namespace MySolidWebApi.Models
{
    public class HandlerHalterofilia : DisciplinaHandler
    {
        public override double handle(Performance performance)
        {
            Console.WriteLine("HALTEROFILIA");
            if (performance.Disciplina.Nombre == "Halterofilia")
            {
                PuntajeHalterofilia puntajeHalterofilia = new PuntajeHalterofilia();

                double score = puntajeHalterofilia.calculateScore(performance);
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