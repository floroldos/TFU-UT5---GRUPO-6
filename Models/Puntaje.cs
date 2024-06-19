namespace MySolidWebApi.Models
{
    public class Puntaje
    {
        public double Calificacion { get; }
        public Puntaje(double calificacion)
        {
            this.Calificacion = calificacion;
        }
    }
}