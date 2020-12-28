using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartScgoole.WebAPI.Models;
using System.Linq;

namespace SmartScgoole.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public AlunoController()
        {            
        }

        public List<Aluno> Alunos = new List<Aluno>(){

            new Aluno(){
                Id = 1,
                Nome="Marcos",
                Sobrenome="Silva",
                Telefone="123456"
            },
             new Aluno(){
                Id = 2,
                Nome="Vinícios",
                Sobrenome="Toscos",
                Telefone="6541237"
            },
             new Aluno(){
                Id = 3,
                Nome="Marta",
                Sobrenome="Almeida",
                Telefone="857414"
            }
        };

        [HttpGet]
        public IActionResult GetAction(){

            return Ok(Alunos);
        }

         [HttpGet("byId/{id}")]
        public IActionResult GetById(int id){
            var  aluno = Alunos.FirstOrDefault(a => a.Id == id);

            if(aluno == null) return BadRequest("O Aluno não foi encontrado!");

            return Ok(aluno);
        }

        //string é o default para o HTTPGet
         [HttpGet("byName")]
        public IActionResult GetByName(string nome, string sobrenome){
            var  aluno = Alunos.FirstOrDefault(a => a.Nome.Contains(nome) && a.Sobrenome.Contains(sobrenome));

            if(aluno == null) return BadRequest("O Aluno não foi encontrado!");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno){

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno){

            return  Ok(aluno);
        }

//atualiza parcialmente
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno){

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id){

            return Ok();
        }
    }
}