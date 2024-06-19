namespace MySolidWebApi.Models
{

    public class Performance
    {
        public int ID { get; }
        public DateTime Fecha { get; }
        public Disciplina Disciplina { get; }
        public Equipo Equipo { get; }
        public Puntaje[] Puntaje { get; }
        public Performance(int ID, DateTime fecha, Disciplina disciplina, Equipo equipo, Puntaje[] puntaje)
        {
            this.ID = ID;
            this.Puntaje = puntaje;
            this.Fecha = fecha;
            this.Equipo = equipo;
            this.Disciplina = disciplina;
        }

        public double puntajeObtenido()
        {
            return 0.0;
        }

    }
}