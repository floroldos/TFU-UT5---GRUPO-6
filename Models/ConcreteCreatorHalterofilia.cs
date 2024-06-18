using MySolidWebApi.Interfaces;

namespace MySolidWebApi.Models
{
    class ConcreteCreatorHalterofilia : CreatorDisciplina
    {
        public override Disciplina createDisciplina(String nombre, Modalidad modalidad)
        {
            return new DisciplinaHalterofilia(nombre, modalidad);
        }
    }

}