using MySolidWebApi.Models;
namespace MySolidWebApi.Models
{
    public class HandlerSurf : DisciplinaHandler
    {
        public override double handle(Performance performance)
        {
            Console.WriteLine("SURF");
            if (performance.Disciplina.Nombre == "Surf")
            {
                PuntajeSurf puntajeSurf = new PuntajeSurf();

                double score = puntajeSurf.calculateScore(performance);
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