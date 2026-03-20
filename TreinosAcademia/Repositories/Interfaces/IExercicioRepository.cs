using TreinosAcademia.Models;

namespace TreinosAcademia.Repositories.Interfaces
{
    public interface IExercicioRepository
    {
        Task Adicionar(Exercicio exercicio);
        Task<Exercicio> ObterPorId(int id);
        Task<IReadOnlyCollection<Exercicio>> ObterTodos();
        Task Atualizar(Exercicio exercicio);
        Task Remover(Exercicio exercicio);
    }
}
