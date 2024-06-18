using MySolidWebApi.Interfaces;
namespace MySolidWebApi.Models
{
    abstract class CreatorDisciplina
    {
        public abstract Disciplina createDisciplina(String nombre, Modalidad modalidad);

    }
}