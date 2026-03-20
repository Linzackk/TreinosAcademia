using Microsoft.AspNetCore.Mvc;
using TreinosAcademia.DTOs.Usuario;
using TreinosAcademia.Services.Interfaces;

namespace TreinosAcademia.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _service;
        public UsuariosController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarUsuario([FromBody] UsuarioCreateDTO usuario)
        {
            var response = await _service.CriarUsuario(usuario);
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
        public async Task<IActionResult> AtualizarParte([FromBody] UsuarioUpdateDTO usuarioAtualizado, int id)
        {
            await _service.Atualizar(usuarioAtualizado, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarUsuario(int id)
        {
            await _service.Remover(id);
            return NoContent();
        }
    }
}
