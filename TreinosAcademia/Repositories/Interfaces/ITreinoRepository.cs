using TreinosAcademia.Models;

namespace TreinosAcademia.Repositories.Interfaces
{
    public interface ITreinoRepository
    {
        Task Adicionar(Treino treino);
        Task<Treino> ObterPorId(int id);
        Task<IReadOnlyCollection<Treino>> ObterTodos();
        Task Atualizar(Treino treino);
        Task Remover(Treino treino);
    }
}
