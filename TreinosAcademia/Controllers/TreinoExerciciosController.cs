using Microsoft.AspNetCore.Mvc;
using TreinosAcademia.DTOs.TreinoExercicio;
using TreinosAcademia.Services.Interfaces;

namespace TreinosAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TreinoExerciciosController : ControllerBase
    {
        private readonly ITreinoExercicioService _service;
        public TreinoExerciciosController(ITreinoExercicioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarTreinoExercicio([FromBody] TreinoExercicioCreateDTO novoTe)
        {
            var response = await _service.AdicionarExercicioAoTreino(novoTe);
            return CreatedAtAction(nameof(ProcurarPorId), new { id = response.Id }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ProcurarPorId(int id)
        {
            var response = await _service.ObterPorId(id);
            return Ok(response);
        }

        [HttpGet("/Treino/{treinoId}")]
        public async Task<IActionResult> ProcurarPorTreinoId(int treinoId)
        {
            var response = await _service.ObterPorTreinoId(treinoId);
            return Ok(response);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> AtualizarTreinoExercicio([FromBody] TreinoExercicioUpdateDTO teAtualizado ,int id)
        {
            await _service.Atualizar(teAtualizado,id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarTreinoExercicio(int id)
        {
            await _service.Remover(id);
            return NoContent();
        }
    }
}
