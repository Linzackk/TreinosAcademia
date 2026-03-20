using AutoMapper;
using TreinosAcademia.DTOs.TreinoExercicio;
using TreinosAcademia.Middleware;
using TreinosAcademia.Models;
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

        private async Task<TreinoExercicio> ObterTe(int id)
        {
            var te = await _repository.ObterPorId(id);
            if (te == null)
                throw new TreinoExercicioNotFound();

            return te;
        }
        public async Task<TreinoExercicioResponseDTO> AdicionarExercicioAoTreino(TreinoExercicioCreateDTO novo)
        {
            var treino = await _treinoService.ObterPorId(novo.TreinoId);
            if (treino == null)
                throw new TreinoNotFound();

            var exercicio = await _exercicioService.ObterPorId(novo.ExercicioId);
            if (exercicio == null)
                throw new ExercicioNotFound();

            var treinoExercicio = _mapper.Map<TreinoExercicio>(novo);
            await _repository.Adicionar(treinoExercicio);
            return _mapper.Map<TreinoExercicioResponseDTO>(treinoExercicio);
        }

        public async Task<IReadOnlyCollection<TreinoExercicioResponseDTO>> ObterPorTreinoId(int treinoId)
        {
            var treinosExercicios = await _repository.ObterPorTreinoId(treinoId);
            return _mapper.Map<List<TreinoExercicioResponseDTO>>(treinosExercicios);
        }
        public async Task<TreinoExercicioResponseDTO> ObterPorId(int id)
        {
            var te = await ObterTe(id);
            return _mapper.Map<TreinoExercicioResponseDTO>(te);
        }
        public async Task Atualizar(TreinoExercicioUpdateDTO teAtualizado, int id)
        {
            if (teAtualizado.Repeticoes == null && teAtualizado.Series == null)
                throw new ArgumentException("Nenhuma informação para atualizar foi inserida.");

            var te = await ObterTe(id);

            if (teAtualizado.Repeticoes != null)
                te.AlterarQuantidadeRepeticoes((int)teAtualizado.Repeticoes);

            if (teAtualizado.Series != null)
                te.AlterarQuantidadeSeries((int)teAtualizado.Series);

            await _repository.Atualizar(te);
        }
        public async Task Remover(int id)
        {
            var te = await ObterTe(id);
            await _repository.Remover(te);
        }
    }
}
