namespace MySolidWebApi.Models
{
    public enum Sexo
    {
        Masculino,
        Femenino
    }
    public class Atleta
    {
        public double Peso { get; }

        public Sexo Sexo { get; }

        public Atleta(double peso, Sexo sexo)
        {
            this.Peso = peso;
            this.Sexo = sexo;
        }

    }
}