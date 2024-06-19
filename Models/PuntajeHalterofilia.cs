using MySolidWebApi.Interfaces;
using System.Linq;
namespace MySolidWebApi.Models
{

    public class PuntajeHalterofilia : IStrategyPuntaje
    {

        public double calculateScore(Performance performance)
        {
            // se levanta 3 veces en arrancada y 3 en dos tiempos
            // sumar el mejor peso de cada uno y multiplicarlo por el SC
            // asumir que el arreglo tiene tamaño 2, uno para cada tipo de levantada, y que este sea el maximo
            if (performance.Puntaje == null)
            {
                throw new Exception("Le falta puntaje a la performance.");
            }
            if (performance.Puntaje.Length < 2)
            {
                throw new Exception("Tienen que haber dos puntajes en la performance.");
            }

            double dosTiempos = performance.Puntaje[0].Calificacion;
            double arrancada = performance.Puntaje[1].Calificacion;
            double totalLevantado = arrancada + dosTiempos;

            Sexo sexo = performance.Equipo.Atletas[0].Sexo;
            double pesoAtleta = performance.Equipo.Atletas[0].Peso;

            return this.calculateScoreUsingSinclair(sexo, pesoAtleta, totalLevantado);
        }

        private double calculateScoreUsingSinclair(Sexo sexo, double pesoAtleta, double totalPesoLevantado)
        {
            // A si M=0.722762521
            // A si F=0.787004341
            // b si M=193.609
            // b si F=153.757
            // sacados de https://iwf.sport/weightlifting_/sinclair-coefficient/

            double A = (sexo == Sexo.Masculino) ? 0.722762521 : 0.787004341;
            double b = (sexo == Sexo.Masculino) ? 193.609 : 153.757;
            double X = (Math.Log(pesoAtleta / b)) / (Math.Log(10));
            double AX2 = A * (X * X);
            double SC = Math.Pow(10, AX2);
            double SCTotal = Math.Round((SC * totalPesoLevantado) * 100) / 100;
            return SCTotal;
        }
    }
    
}