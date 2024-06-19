using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{
    public class Disciplina
    {
        private IStrategyPuntaje strategy;
        public string Nombre { get; }
        public Modalidad Modalidad { get; }

        public Disciplina(string nombre, Modalidad modalidad)
        {
            this.Nombre = nombre;
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
