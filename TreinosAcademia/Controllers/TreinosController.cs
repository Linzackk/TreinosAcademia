using Microsoft.AspNetCore.Mvc;
using TreinosAcademia.DTOs.Treino;
using TreinosAcademia.Services.Interfaces;

namespace TreinosAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreinosController : ControllerBase
    {
        private readonly ITreinoService _service;
        public TreinosController(ITreinoService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTreino([FromBody] TreinoCreateDTO novoTreino)
        {
            var response = await _service.Criar(novoTreino);
            return CreatedAtAction(nameof(ProcurarPorId), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProcurarPorId(int id)
        {
            var response = await _service.ObterPorId(id);
            return Ok(response);
        }

        [HttpGet("/Usuario/{userId}")]
        public async Task<IActionResult> ProcurarPorIdUsuario(int userId)
        {
            var response = await _service.ObterTodosPorUsuarioId(userId);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarTreino([FromBody] TreinoUpdateDTO treinoAtualiado ,int id)
        {
            await _service.Atualizar(treinoAtualiado, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTreino(int id)
        {
            await _service.Remover(id);
            return NoContent();
        }
    }
}
