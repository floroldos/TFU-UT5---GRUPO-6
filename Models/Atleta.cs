
using System.Text.Json.Serialization;

namespace MySolidWebApi.Models
{
    public enum Sexo
    {
        Masculino,
        Femenino
    }
    public class Atleta
    {
        [JsonPropertyName("Nombre")]

        public string Nombre { get; set; }

        [JsonPropertyName("Peso")]

        public double Peso { get; set; }

        [JsonPropertyName("Sexo")]

        public Sexo Sexo { get; set; }

        [JsonConstructor]
        public Atleta(string nombre, double peso, Sexo sexo)
        {
            this.Nombre = nombre;
            this.Peso = peso;
            this.Sexo = sexo;
        }

        public Atleta()
        {

        }

    }
}