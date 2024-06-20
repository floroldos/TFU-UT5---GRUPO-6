using MySolidWebApi.Interfaces;

namespace MySolidWebApi.Models
{

    public class Performance
    {
        public float ID { get; }
        public DateTime Fecha { get; }
        public Disciplina Disciplina { get; set; }
        public Equipo Equipo { get; set; }
        public Puntaje[] Puntaje { get; set; }
        public double puntajeObtenido { get; set; }
        public Performance(float ID, DateTime fecha, Disciplina disciplina, Equipo equipo, Puntaje[] puntaje)
        {
            this.ID = ID;
            this.Puntaje = puntaje;
            this.Fecha = fecha;
            this.Equipo = equipo;
            this.Disciplina = disciplina;
        }
    }
}