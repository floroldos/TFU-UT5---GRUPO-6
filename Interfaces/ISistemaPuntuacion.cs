namespace MySolidWebApi.Interfaces
{
    public interface ISistemaPuntuacion
    {
        // Me queda la duda de si se le debe pasar el arreglo con los puntajes? O capaz que se le puede pasar la performance
        // y que el sistema te calcule el score dependiendo del tipo de disciplina/sistema que use
        double CalculateFinalScore(double[] scores);
    }
}
