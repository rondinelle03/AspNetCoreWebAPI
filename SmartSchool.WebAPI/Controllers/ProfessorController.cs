using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
      
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;

        }


        [HttpGet]
        public IActionResult Get()
        {   
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

        // api/professor
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {   
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest(" o professor não foi encontrado");

            return Ok(professor);
        }

        // api/professor
        [HttpPost]
        public IActionResult Post (Professor professor)
        {   
             _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("professor não cadastrado");
        }

        // api/professor
        [HttpPut("{id}")]
        public IActionResult Put (int id, Professor professor)
        {   

            var prf = _repo.GetProfessorById(id);
            if (prf == null) return BadRequest("Aluno não encontrado");

             _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado");

        }

         // api/professor
        [HttpPatch("{id}")]
        public IActionResult Patch (int id, Professor professor)
        {   
           var prf = _repo.GetProfessorById(id);
            if (prf == null) return BadRequest("Aluno não encontrado");

             _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }

            return BadRequest("Professor não atualizado");
        }

        // api/professor
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {   
            var alu = _repo.GetProfessorById(id);
            if (alu == null) return BadRequest("Professor não encontrado");

             _repo.Delete(alu);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado");
            }

            return BadRequest("Professor não deletado");
        }
    }
}