using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WEbAPI.Data;
using SmartSchool.WEbAPI.Models;

namespace SmartSchool.WEbAPI.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class AlunoController : ControllerBase
   {
      private readonly SmartContext _context;

      public AlunoController(SmartContext context )
      {
         _context = context;
      }


      [HttpGet]
      public IActionResult Get()
      {
         return Ok(_context.Alunos);
      }

      [HttpGet("{id}")]
      public IActionResult GetById(int id)
      {
         var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
         if(aluno == null) return BadRequest("O aluno não foi encontrado.");
         
         return Ok(aluno);
      }   

      [HttpGet("ByName")]
      public IActionResult GetByName(string nome, string sobrenome)
      {
         var aluno = _context.Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
         );
         if(aluno == null) return BadRequest("O aluno não foi encontrado.");
         
         return Ok(aluno);
      }

      [HttpPost]
      public IActionResult Post(Aluno aluno)
      {
         _context.Add(aluno);
         _context.SaveChanges();
         return Ok(aluno);
      } 

      [HttpPut("{id}")]
      public IActionResult Put(int id, Aluno aluno)
      {
         var alunoP = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
         if(alunoP == null) return BadRequest("O aluno não foi encontrado.");

         _context.Update(aluno);
         _context.SaveChanges();
         return Ok(aluno);
      }

      [HttpPatch("{id}")]
      public IActionResult Patch(int id, Aluno aluno)
      {
         var alunoP = _context.Alunos.FirstOrDefault(a => a.Id == id);
         if(alunoP == null) return BadRequest("O aluno não foi encontrado.");

         _context.Update(aluno);
         _context.SaveChanges();
         return Ok(aluno);
      }

      [HttpDelete("{id}")]
      public IActionResult Delete(int id)
      {
         var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
         if(aluno == null) return BadRequest("O aluno não foi encontrado.");

         _context.Remove(aluno);
         _context.SaveChanges();
         return Ok();
      }   
   }   
}