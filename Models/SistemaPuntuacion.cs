namespace MySolidWebApi.Models
{
    // Me parece que esta clase hay que sacarla ya que ahora esta el factory del Sistema de puntuacion
    public abstract class SistemaPuntuacion
    {
        public string[] Reglas { get; set; }
        
        public abstract double CalculateFinalScore(double[] scores);
    }
}
