using System.Text.Json.Serialization;

namespace MySolidWebApi.Models
{


    public class Equipo
    {
        [JsonPropertyName("Atletas")]
        public Atleta[] Atletas { get; set; }

        [JsonPropertyName("Nombre")]
        public string Nombre { get; set; }


        [JsonConstructor]
        public Equipo(string nombre, Atleta[] atletas)
        {
            this.Nombre = nombre;
            this.Atletas = atletas;
        }

        public Equipo()
        {

        }
    }
}