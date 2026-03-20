using TreinosAcademia.Models;

namespace TreinosAcademia.Repositories.Interfaces
{
    public interface ITreinoExercicioRepository
    {
        Task Adicionar(TreinoExercicio treinoExercicio);

        Task<IReadOnlyCollection<TreinoExercicio>> ObterPorTreinoId(int treinoId);
        Task<TreinoExercicio> ObterPorId(int id);
        Task Atualizar(TreinoExercicio treinoExercicio);
        Task Remover(TreinoExercicio treinoExercicio);
    }
}
