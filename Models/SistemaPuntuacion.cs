namespace MySolidWebApi.Models
{
    public abstract class SistemaPuntuacion
    {
        public string[] Reglas { get; set; }

        public abstract double CalculateFinalScore(double[] scores);
    }
}
