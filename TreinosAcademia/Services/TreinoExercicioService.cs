using AutoMapper;
using TreinosAcademia.DTOs.TreinoExercicio;
using TreinosAcademia.Middleware;
using TreinosAcademia.Repositories.Interfaces;
using TreinosAcademia.Services.Interfaces;

namespace TreinosAcademia.Services
{
    public class TreinoExercicioService : ITreinoExercicioService
    {
        private readonly ITreinoExercicioRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITreinoService _treinoService;
        private readonly IExercicioService _exercicioService;

        public TreinoExercicioService(ITreinoExercicioRepository repository, IMapper mapper, ITreinoService treinoService, IExercicioService exercicioService)
        {
            _repository = repository;
            _mapper = mapper;
            _treinoService = treinoService;
            _exercicioService = exercicioService;
        }

        public async Task<TreinoExercicioResponseDTO> AdicionarExercicioAoTreino(TreinoExercicioCreateDTO novo)
        {
            var treino = await _treinoService.ObterPorId(novo.TreinoId);
            if (treino == null)
                throw new TreinoNotFound();

            var exercicio = await _exercicioService.ObterPorId(novo.ExercicioId);
            if (exercicio == null)
                throw new ExercicioNotFound();
        }
    }
}
