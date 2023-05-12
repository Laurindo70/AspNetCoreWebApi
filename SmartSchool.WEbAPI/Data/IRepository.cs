using SmartSchool.WEbAPI.Models;

namespace SmartSchool.WEbAPI.Data
{
   public interface IRepository
   {
      void Add<T>(T entity) where T : class;
      void Update<T>(T entity) where T : class;
      void Delete<T>(T entity) where T : class;
      bool SaveChanges();

      // ALUNOS
      Aluno[] GetAllAlunos(bool includeProfessor = false);
      Aluno[] GetAllAlunosByDisciplicaId(int discplicaId, bool includeProfessor = false);
      Aluno GetAlunoById(int alunoId, bool includeProfessor = false);

      // PROFESSORES
      Professor[] GetAllProfessores(bool includeAlunos = false);
      Professor[] GetAllProfessoresByDisciplicaId(int disciplinaId, bool includeAlunos = false);
      Professor GetProfessorById(int professorId, bool includeAlunos = false);
   }
}