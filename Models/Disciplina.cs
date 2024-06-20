using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{
    public class Disciplina
    {
        private IStrategyPuntaje strategy;
        public string Nombre { get; set; }
        public Modalidad Modalidad { get; set; }
        public IScoreService ScoreService { get; set; }

        public Disciplina(string nombre, IScoreService service, Modalidad modalidad)
        {
            this.Nombre = nombre;
            this.ScoreService = service;
            this.Modalidad = modalidad;
        }

        public void setStrategyPuntaje(IStrategyPuntaje strategy)
        {
            this.strategy = strategy;
        }

        public double calculateScore(Performance performance)
        {
            return strategy.calculateScore(performance);
        }

    }
}
