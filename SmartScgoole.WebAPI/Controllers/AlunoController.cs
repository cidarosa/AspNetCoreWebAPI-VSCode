using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartScgoole.WebAPI.Models;
using SmartScgoole.WebAPI.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SmartScgoole.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;
        public readonly IRepository _repo;

        public AlunoController(SmartContext context, IRepository repo)
        {
            _repo = repo;
            _context = context;
        }


        [HttpGet]
        public IActionResult GetAction()
        {

            return Ok(_context.Alunos);
        }

        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");

            return Ok(aluno);
        }

        //string é o default para o HTTPGet
        [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if (aluno == null) return BadRequest("O Aluno não foi encontrado!");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            /*
            _context.Add(aluno);
            _context.SaveChanges();
            */
            _repo.Add(aluno);
            
            if (_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não cadastrado");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {

            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        //atualiza parcialmente
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {

            var alu = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
            if (alu == null) return BadRequest("Aluno não encontrado");

            _context.Update(aluno);
            _context.SaveChanges();
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);

            if (aluno == null) return BadRequest("Aluno não encontrado");

            _context.Remove(aluno);
            _context.SaveChanges();
            return Ok();
        }
    }
}