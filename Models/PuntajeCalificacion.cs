using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{

    public class Calificacion : IPuntaje
    {
        public double calificacion { get; set; }

        public Calificacion(double calificacion)
        {
            this.calificacion = calificacion;
        }

        public double getPuntaje()
        {
            return calificacion;
        }

    }

}