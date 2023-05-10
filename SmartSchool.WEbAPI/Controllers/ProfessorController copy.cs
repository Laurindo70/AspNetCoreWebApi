using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WEbAPI.Controllers
{
   [ApiController]
   [Route("api/[controller]")]
   public class ProfessorController : ControllerBase
   {
      public ProfessorController() { }
      
      [HttpGet]
      public IActionResult Get()
      {
         return Ok("Professores: Marta, Paula, Lucas, Rafa");
      }   
   }   
}