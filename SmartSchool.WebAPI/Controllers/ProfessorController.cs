using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
      
        private readonly IRepository _repo;
        private readonly IMapper _mapper;


        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }


        [HttpGet]
        public IActionResult Get()
        {   
            var professores = _repo.GetAllProfessores(true);
           
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

        // api/professor
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {   
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest(" o professor não foi encontrado");

            var professorDto = _mapper.Map<ProfessorDto>(professor);

            return Ok(professorDto);
        }

        // api/professor/
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {   
            return Ok(new ProfessorRegistrarDto());
        }

        // api/professor
        [HttpPost]
        public IActionResult Post (ProfessorRegistrarDto model)
        {   
            
            var professor = _mapper.Map<Professor>(model);

            _repo.Add(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não cadastrado");

        }


        // api/professor
        [HttpPut("{id}")]
        public IActionResult Put (int id, ProfessorRegistrarDto model)
        {   

            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado");

            _mapper.Map(model, professor);

             _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não atualizado");

        }

         // api/professor
        [HttpPatch("{id}")]
        public IActionResult Patch (int id, ProfessorRegistrarDto model)
        {   
           var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado");

             _mapper.Map(model, professor);

             _repo.Update(professor);
            if (_repo.SaveChanges())
            {
                 return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }

            return BadRequest("Professor não atualizado");
        }

        // api/professor
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {   
            var professor = _repo.GetProfessorById(id);
            if (professor == null) return BadRequest("Professor não encontrado");

             _repo.Delete(professor);
            if (_repo.SaveChanges())
            {
                return Ok("Professor deletado");
            }

            return BadRequest("Professor não deletado");
        }
    }
}