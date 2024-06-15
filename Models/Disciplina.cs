namespace MySolidWebApi.Models
{
    public class Disciplina
    {
        public string Nombre { get; set; }
        public SistemaPuntuacion SistemaPuntuacion { get; set; }
        public Modalidad Modalidad { get; set; }

        public Disciplina(string nombre, SistemaPuntuacion sistemaPuntuacion, Modalidad modalidad)
        {
            Nombre = nombre;
            SistemaPuntuacion = sistemaPuntuacion;
            Modalidad = modalidad;
        }
    }
}
