using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Helpers;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        
        private readonly IRepository _repo;

        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
           
        }

      
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PageParams pageParams)
        {   
           var alunos = await _repo.GetAllAlunosAsync(pageParams, true);

           var alunosResult =  _mapper.Map<IEnumerable<AlunoDto>>(alunos);

           Response.AddPagination(alunos.CurrentPage, alunos.PageSize,alunos.TotalCount, alunos.TotalPages);
           
           return Ok(alunosResult);
        }

        // api/aluno/
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {   
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest(" o aluno não foi encontrado");


            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);
        }

        // api/aluno/
        [HttpGet("getRegister")]
        public IActionResult GetRegister()
        {   
            return Ok(new AlunoRegistrarDto());
        }

       
        // api/aluno
        [HttpPost]
        public IActionResult Post (AlunoRegistrarDto model)
        {   

            var aluno = _mapper.Map<Aluno>(model);

            _repo.Add(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não cadastrado");
        }

        // api/aluno
        [HttpPut("{id}")]
        public IActionResult Put (int id, AlunoRegistrarDto model)
        {   

            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, aluno);

             _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não cadastrado");
        }

         // api/aluno
        [HttpPatch("{id}")]
        public IActionResult Patch (int id, AlunoRegistrarDto model)
        {   
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

            _mapper.Map(model, aluno);

             _repo.Update(aluno);
            if (_repo.SaveChanges())
            {
                return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
            }

            return BadRequest("Aluno não atualizado");
        }

        // api/aluno
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {   
            var aluno = _repo.GetAlunoById(id);
            if (aluno == null) return BadRequest("Aluno não encontrado");

             _repo.Delete(aluno);
            if (_repo.SaveChanges())
            {
                return Ok("Aluno deletado");
            }

            return BadRequest("Aluno não deletado");
        }
    }
}