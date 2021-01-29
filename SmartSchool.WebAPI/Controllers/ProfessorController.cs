using Microsoft.AspNetCore.Mvc;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController() {}

        [HttpGet]
        public IActionResult GetAction()
        {   
            return Ok("Professores: Marta, Paula, juam ");
         }
    }
}