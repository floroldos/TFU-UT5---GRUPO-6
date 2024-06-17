using MySolidWebApi.Interfaces;

namespace MySolidWebApi.Models
{
    class ConcreteCreatorSPHalterofilia : CreatorSP
    {
        public override ISistemaPuntuacion createSistemaPuntuacion()
        {
            return new SistemaPuntuacionHalterofilia();
        }

    }

}