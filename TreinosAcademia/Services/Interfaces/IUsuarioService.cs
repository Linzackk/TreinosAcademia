using TreinosAcademia.DTOs.Usuario;
using TreinosAcademia.Models;

namespace TreinosAcademia.Services.Interfaces
{
    public interface IUsuarioService
    {
        public Task<UsuarioResponseDTO> CriarUsuario(UsuarioCreateDTO novoUsuario);
        public Task<UsuarioResponseDTO> ObterPorId(int id);
        public Task<IReadOnlyCollection<UsuarioResponseDTO>> ObterTodos();
        public Task Atualizar(UsuarioUpdateDTO usuarioUpdate, int id);
        public Task Remover(int usuarioId);
    }
}
