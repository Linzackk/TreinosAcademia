using TreinosAcademia.DTOs.TreinoExercicio;

namespace TreinosAcademia.Services.Interfaces
{
    public interface ITreinoExercicioService
    {
        public Task<TreinoExercicioResponseDTO> AdicionarExercicioAoTreino(TreinoExercicioCreateDTO teNovo);
        public Task<IReadOnlyCollection<TreinoExercicioResponseDTO>> ObterPorTreinoId(int treinoId);
        public Task Atualizar(TreinoExercicioUpdateDTO teAtualizado, int id);
        public Task Remover(int id);
    }
}
