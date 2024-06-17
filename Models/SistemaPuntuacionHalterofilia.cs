using MySolidWebApi.Interfaces;

namespace MySolidWebApi.Models
{
    class SistemaPuntuacionHalterofilia : ISistemaPuntuacion
    {
        public int pesoArrancada { get; set; }
        public int pesoDosTiempos { get; set; }
        public double coeficienteSinclair { get; set; }
        public double CalculateFinalScore(double[] scores)
        {
            return (this.pesoArrancada + this.pesoDosTiempos) * this.coeficienteSinclair;
        }

    }

}