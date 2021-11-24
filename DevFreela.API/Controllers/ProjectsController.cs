using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")] // pega o nome antes do sufixo Controller
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectService _projectService;
        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet]
        public IActionResult Get(string query) // query string é uma informação via url api/projects?query=teste
        {
            var projects = _projectService.GetAll(query);
            return Ok(projects); // Ok funciona apenas porque essa controller herda de ControllerBase
        }

        [HttpGet("{id}")] // podemos usar parâmetros na própria controller, chamando pela url: api/projects/{id}
        public IActionResult GetById(int id)
        {
            var project = _projectService.GetById(id);

            if(project == null)
            {
                return NotFound();
            }

            return Ok(project); // Caso encontre o projeto
            // return NotFound(); // Se não recontrar
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewProjectInputModel inputModel) // recebe no corpo da requisição o objeto do modelo selecionado
        {
            if(inputModel.Title.Length > 50)
            {
                return BadRequest(); // se algo der errado na validação
            }

            var id = _projectService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel); // 201 com o modelo de saída
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateProjectInputModel inputModel) // o put precisa buscar e atualiza a partir do corpo
        {
            if (inputModel.Description.Length > 200)
            {
                return BadRequest(); // se algo der errado na validação
            }

            _projectService.Update(inputModel);

            return NoContent(); // Atualizou, não precisa retornar nada: 404
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Busca para "deletar", se não, notfound

            _projectService.Delete(id);

            return NoContent();
        }

        [HttpPost("{id}/comments")] // api/projects/{id}/comments
        public IActionResult PostComment([FromBody] CreateCommentInputModel inputModel)
        {
            _projectService.CreateComment(inputModel);

            return NoContent();
        }

        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            _projectService.Start(id);
            return NoContent();
        }

        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            _projectService.Finish(id);

            return NoContent();
        }


    }
}
