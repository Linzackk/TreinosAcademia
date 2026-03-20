using TreinosAcademia.DTOs.Treino;

namespace TreinosAcademia.Services.Interfaces
{
    public interface ITreinoService
    {
        public Task<TreinoResponseDTO> Criar(TreinoCreateDTO novoTreino);
        public Task<TreinoResponseDTO> ObterPorId(int id);
        public Task<IReadOnlyCollection<TreinoResponseDTO>> ObterTodosPorUsuarioId(int usuarioId);
        public Task Atualizar(TreinoUpdateDTO treinoAtualizado, int id);
        public Task Remover(int id);
    }
}
