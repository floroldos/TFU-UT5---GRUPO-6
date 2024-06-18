using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{
    public abstract class Disciplina
    {
        public string Nombre { get; set; }
        public Modalidad modalidad { get; set; }

        public abstract double CalculateFinalScore(IPuntaje[] puntajes);

        public Disciplina(string nombre, Modalidad modalidad)
        {
            Nombre = nombre;
            modalidad = modalidad;
        }
    }
}
