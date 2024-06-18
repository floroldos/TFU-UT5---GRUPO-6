using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{

    public class Tiempo : IPuntaje
    {
        public double tiempo { get; set; } // en segundos

        public Tiempo(double tiempo)
        {
            this.tiempo = tiempo;
        }

        public double getPuntaje()
        {
            return tiempo;
        }

    }

}