using MySolidWebApi.Interfaces;

namespace MySolidWebApi.Models
{

    public class Performance
    {
        public float ID { get; }
        public DateTime Fecha { get; }
        public Disciplina Disciplina { get; }
        public Equipo Equipo { get; }
        public Puntaje[] Puntaje { get; }
        public IScore Score;
        public Performance(float ID, DateTime fecha, Disciplina disciplina, Equipo equipo, Puntaje[] puntaje, IScore score)
        {
            this.ID = ID;
            this.Puntaje = puntaje;
            this.Fecha = fecha;
            this.Equipo = equipo;
            this.Disciplina = disciplina;
            this.Score = score;
        }

    }
}