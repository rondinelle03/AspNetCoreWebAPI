using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() {
            new Aluno() {
                Id = 1,
                Nome = "Marcos",
                Sobrenome = "Kenbt",
                Telefone = "123444gg"
            },
            new Aluno() {
                Id = 2,
                Nome = "Marta",
                Sobrenome = "tilico",
                Telefone = "896554"
            },
            new Aluno() {
                Id = 3,
                Nome = "Laura",
                Sobrenome = "raizr",
                Telefone = "487566"
            }
        };
        public AlunoController() {}

        [HttpGet]
        public IActionResult GetAction()
        {   
            return Ok(Alunos);
        }

        // api/aluno/byId
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {   
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest(" o aluno não foi enbcontrato");

            return Ok(aluno);
        }

        // api/aluno/nome
        [HttpGet("Byname")]
        public IActionResult GetByName(string nome, string Sobrenome)
        {   
            var aluno = Alunos.FirstOrDefault(a => 
                a.Nome.Contains(nome) && a.Sobrenome.Contains(Sobrenome));
            if (aluno == null) return BadRequest(" o aluno não foi enbcontrato");

            return Ok(aluno);
        }


        // api/aluno
        [HttpPost]
        public IActionResult Post (Aluno aluno)
        {   
            return Ok(aluno);
        }

        // api/aluno
        [HttpPut("{id}")]
        public IActionResult Put (int id, Aluno aluno)
        {   
            return Ok(aluno);
        }

         // api/aluno
        [HttpPatch("{id}")]
        public IActionResult Patch (int id, Aluno aluno)
        {   
            return Ok(aluno);
        }

        // api/aluno
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {   
            return Ok();
        }
    }
}