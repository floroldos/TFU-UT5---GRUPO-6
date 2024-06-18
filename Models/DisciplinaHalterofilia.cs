using MySolidWebApi.Interfaces;
using MySolidWebApi.Models;
namespace MySolidWebApi.Models
{
    public class DisciplinaHalterofilia : Disciplina
    {
        public DisciplinaHalterofilia(string nombre, Modalidad modalidad) : base(nombre, modalidad)
        {

        }

        public override double CalculateFinalScore(IPuntaje[] puntaje)
        {
            double suma = 0;
            foreach (IPuntaje p in puntaje)
            {
                suma += p.getPuntaje();
            }

            return suma;
        }

    }

}