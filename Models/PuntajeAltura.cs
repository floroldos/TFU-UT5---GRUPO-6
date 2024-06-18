using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{

    public class Altura : IPuntaje
    {
        public double altura { get; set; }

        public Altura(double altura)
        {
            this.altura = altura;
        }

        public double getPuntaje()
        {
            return altura;
        }

    }

}