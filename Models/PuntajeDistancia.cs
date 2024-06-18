using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{

    public class Distancia : IPuntaje
    {
        public double distancia { get; set; }

        public Distancia(double distancia)
        {
            this.distancia = distancia;
        }

        public double getPuntaje()
        {
            return distancia;
        }

    }

}