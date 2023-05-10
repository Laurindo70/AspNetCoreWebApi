using Microsoft.AspNetCore.Mvc;
using SmartSchool.WEbAPI.Models;

namespace SmartSchool.WEbAPI.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class AlunoController : ControllerBase
   {
      public List<Aluno> Alunos = new List<Aluno>(){
         new Aluno(){
            Id = 1,
            Nome = "Marcos",
            Sobrenome = "Almeida",
            Telefone = "12313"
         },
         new Aluno(){
            Id = 2,
            Nome = "Marta",
            Sobrenome = "Kent",
            Telefone = "12313"
         },
         new Aluno(){
            Id = 3,
            Nome = "Lucas",
            Sobrenome = "Almeida",
            Telefone = "12313"
         }
      };
      public AlunoController() { }
      
      [HttpGet]
      public IActionResult Get()
      {
         return Ok(Alunos);
      }

      [HttpGet("{id}")]
      public IActionResult GetById(int id)
      {
         var aluno = Alunos.FirstOrDefault(a => a.Id == id);
         if(aluno == null) return BadRequest("O aluno não foi encontrado.");
         
         return Ok(aluno);
      }   

      [HttpGet("ByName")]
      public IActionResult GetByName(string nome, string sobrenome)
      {
         var aluno = Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome)
         );
         if(aluno == null) return BadRequest("O aluno não foi encontrado.");
         
         return Ok(aluno);
      }

      [HttpPost]
      public IActionResult Post(Aluno aluno)
      {
         return Ok(aluno);
      } 

      [HttpPut("{id}")]
      public IActionResult Put(int id, Aluno aluno)
      {
         return Ok();
      }

      [HttpPatch("{id}")]
      public IActionResult Patch(int id, Aluno aluno)
      {
         return Ok();
      }

      [HttpDelete("{id}")]
      public IActionResult Delete(int id, Aluno aluno)
      {
         return Ok();
      }   
   }   
}