namespace MySolidWebApi.Models
{
    public class Modalidad
    {
        public string Nombre { get; set; }
        public string Categoria { get; set; }

        public Modalidad(string nombre, string categoria)
        {
            this.Categoria = categoria;
            this.Nombre = nombre;
        }
    }
}
