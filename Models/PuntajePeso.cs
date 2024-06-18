using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{

    public class Peso : IPuntaje
    {
        public double peso { get; set; }
        public double sinclair { get; set; }

        public Peso(double peso, double sinclair)
        {
            this.peso = peso;
            this.sinclair = sinclair;
        }

        public double getPuntaje()
        {
            return peso * sinclair;
        }

    }

}