using AutoMapper;
using TreinosAcademia.DTOs.Exercicio;
using TreinosAcademia.Middleware;
using TreinosAcademia.Models;
using TreinosAcademia.Repositories.Interfaces;
using TreinosAcademia.Services.Interfaces;

namespace TreinosAcademia.Services
{
    public class ExercicioService : IExercicioService
    {
        private readonly IExercicioRepository _repository;
        private readonly IMapper _mapper;

        public ExercicioService(IExercicioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        private async Task<Exercicio> ObterExercicio(int id)
        {
            var exercicio = await _repository.ObterPorId(id);
            if (exercicio == null)
                throw new ExercicioNotFound();

            return exercicio;
        }

        public async Task<ExercicioResponseDTO> Criar(ExercicioCreateDTO novoExercicio)
        {
            var exercicio = _mapper.Map<Exercicio>(novoExercicio);
            await _repository.Adicionar(exercicio);
            return _mapper.Map<ExercicioResponseDTO>(exercicio);
        }

        public async Task<ExercicioResponseDTO> ObterPorId(int id)
        {
            var exercicio = await ObterExercicio(id);
            return _mapper.Map<ExercicioResponseDTO>(exercicio);
        }

        public async Task<IReadOnlyCollection<ExercicioResponseDTO>> ObterTodos()
        {
            var exercicios = await _repository.ObterTodos();
            return _mapper.Map<List<ExercicioResponseDTO>>(exercicios);
        }

        public async Task Remover(int id)
        {
            var exercicio = await ObterExercicio(id);
            await _repository.Remover(exercicio);
        }

        public async Task Atualizar(ExercicioUpdateDTO exercicioAtualizado, int id)
        {
            if (exercicioAtualizado.Nome == null && exercicioAtualizado.Regiao == null)
                throw new ArgumentException("Nenhum valor para atualização foi inserido.");

            var exercicioBanco = await ObterExercicio(id);

            if (exercicioAtualizado.Nome != null)
                exercicioBanco.AlterarNome(exercicioAtualizado.Nome);

            if (exercicioAtualizado.Regiao != null)
                exercicioBanco.AlterarRegiao((RegiaoMuscular)exercicioAtualizado.Regiao);

            await _repository.Atualizar(exercicioBanco);
        }
    }
}
