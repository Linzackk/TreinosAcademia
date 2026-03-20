using TreinosAcademia.Models;

namespace TreinosAcademia.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task Adicionar(Usuario usuario);
        Task<Usuario> ObterPorId(int id);
        Task<IReadOnlyCollection<Usuario>> ObterTodos();
        Task Atualizar(Usuario usuarioAtualizado);
        Task Remover(Usuario usuario);
    }
}
