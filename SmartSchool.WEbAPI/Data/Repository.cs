using Microsoft.EntityFrameworkCore;
using SmartSchool.WEbAPI.Models;

namespace SmartSchool.WEbAPI.Data
{

   public class Repository : IRepository
   {
      private readonly SmartContext _context;

      public Repository(SmartContext context)
      {
         _context = context;
      }
      public void Add<T>(T entity) where T : class
      {
         _context.Add(entity);
      }

      public void Update<T>(T entity) where T : class
      {
         _context.Update(entity);
      }

      public void Delete<T>(T entity) where T : class
      {
         _context.Remove(entity);
      }

      public bool SaveChanges()
      {
         return (_context.SaveChanges() > 0);
      }

      public Aluno[] GetAllAlunos(bool includeProfessor = false)
      {
         IQueryable<Aluno> query = _context.Alunos;

         if(includeProfessor)
         {
            query = query.Include(a => a.AlunosDiciplinas)
                           .ThenInclude(ad => ad.Disciplina)
                           .ThenInclude(d => d.Professor);
         }

         query = query.AsNoTracking().OrderBy(a => a.Id);

         return query.ToArray();
      }

      public Aluno[] GetAllAlunosByDisciplicaId(int discplicaId, bool includeProfessor = false)
      {
         IQueryable<Aluno> query = _context.Alunos;

         if(includeProfessor)
         {
            query = query.Include(a => a.AlunosDiciplinas)
                           .ThenInclude(ad => ad.Disciplina)
                           .ThenInclude(d => d.Professor);
         }

         query = query.AsNoTracking()
                        .OrderBy(a => a.Id)
                        .Where(aluno => aluno.AlunosDiciplinas.Any(ad => ad.DisciplinaId == discplicaId));

         return query.ToArray();
      }

      public Aluno GetAlunoById(int alunoId, bool includeProfessor = false)
      {
         IQueryable<Aluno> query = _context.Alunos;

         if(includeProfessor)
         {
            query = query.Include(a => a.AlunosDiciplinas)
                           .ThenInclude(ad => ad.Disciplina)
                           .ThenInclude(d => d.Professor);
         }

         query = query.AsNoTracking()
                     .OrderBy(a => a.Id)
                     .Where(aluno => aluno.Id == alunoId);

         return query.FirstOrDefault();
      }

      public Professor[] GetAllProfessores(bool includeAlunos = false)
      {
         IQueryable<Professor> query = _context.Professores;

         if(includeAlunos)
         {
            query = query.Include(p => p.Disciplinas)
                        .ThenInclude(d => d.AlunosDiciplinas)
                        .ThenInclude(ad => ad.Aluno);
         }

         query = query.AsNoTracking()
                     .OrderBy(p => p.Id);

         return query.ToArray();
      }

      public Professor[] GetAllProfessoresByDisciplicaId(int disciplinaId, bool includeAlunos = false)
      {
         IQueryable<Professor> query = _context.Professores;

         if(includeAlunos)
         {
            query = query.Include(p => p.Disciplinas)
                        .ThenInclude(d => d.AlunosDiciplinas)
                        .ThenInclude(ad => ad.Aluno);
         }

         query = query.AsNoTracking()
                     .OrderBy(p => p.Id)
                     .Where(aluno => aluno.Disciplinas.Any(
                        d => d.AlunosDiciplinas.Any(ad => ad.DisciplinaId == disciplinaId)
                     ));

         return query.ToArray();
      }

      public Professor GetProfessorById(int professorId, bool includeAlunos = false)
      {
        IQueryable<Professor> query = _context.Professores;

         if(includeAlunos)
         {
            query = query.Include(p => p.Disciplinas)
                        .ThenInclude(d => d.AlunosDiciplinas)
                        .ThenInclude(ad => ad.Aluno);
         }

         query = query.AsNoTracking()
                     .OrderBy(p => p.Id)
                     .Where(prof => prof.Id == professorId);

         return query.FirstOrDefault();
      }
   }
}