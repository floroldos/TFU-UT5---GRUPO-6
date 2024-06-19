namespace MySolidWebApi.Models
{


    public class Equipo
    {
        public List<Atleta> Atletas = [];

        public String Nombre;
        public Equipo(String nombre)
        {
            this.Nombre = nombre;
        }

    }
}