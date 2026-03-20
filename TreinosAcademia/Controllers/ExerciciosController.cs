using Microsoft.AspNetCore.Mvc;
using TreinosAcademia.DTOs.Exercicio;
using TreinosAcademia.Services.Interfaces;

namespace TreinosAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciciosController : ControllerBase
    {
        private readonly IExercicioService _service;
        public ExerciciosController(IExercicioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarExercicio([FromBody] ExercicioCreateDTO novoExercicio) 
        {
            var response = await _service.Criar(novoExercicio);
            return CreatedAtAction(nameof(ProcurarPorId), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProcurarPorId(int id)
        {
            var response = await _service.ObterPorId(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> ProcurarTodos()
        {
            var response = await _service.ObterTodos();
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarExercicio([FromBody] ExercicioUpdateDTO exercicioAtualizado, int id)
        {
            await _service.Atualizar(exercicioAtualizado, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarExercicio(int id)
        {
            await _service.Remover(id);
            return NoContent();
        }
    }
}
