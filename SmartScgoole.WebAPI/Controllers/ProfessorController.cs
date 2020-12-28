using Microsoft.AspNetCore.Mvc;

namespace SmartScgoole.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController()
        {
            
        }


        [HttpGet]
        public IActionResult GetAction(){

            return Ok("Professores: Cida, Luiz");
        }
    }
}