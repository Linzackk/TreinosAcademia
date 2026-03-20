using TreinosAcademia.DTOs.Exercicio;

namespace TreinosAcademia.Services.Interfaces
{
    public interface IExercicioService
    {
        public Task<ExercicioResponseDTO> Criar(ExercicioCreateDTO novoExercicio);
        public Task<IReadOnlyCollection<ExercicioResponseDTO>> ObterTodos();
        public Task<ExercicioResponseDTO> ObterPorId(int id);
        public Task Atualizar(ExercicioUpdateDTO exercicioAtualizado, int id);
        public Task Remover(int id);
    }
}
