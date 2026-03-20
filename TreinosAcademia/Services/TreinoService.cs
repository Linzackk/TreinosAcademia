using AutoMapper;
using TreinosAcademia.DTOs.Treino;
using TreinosAcademia.Middleware;
using TreinosAcademia.Models;
using TreinosAcademia.Profiles;
using TreinosAcademia.Repositories.Interfaces;
using TreinosAcademia.Services.Interfaces;

namespace TreinosAcademia.Services
{
    public class TreinoService : ITreinoService
    {
        private readonly ITreinoRepository _repository;
        private readonly IMapper _mapper;
        private readonly ITreinoExercicioService _exercicioService;
        public TreinoService(ITreinoRepository repository, IMapper mapper, ITreinoExercicioService exercicioService)
        {
            _repository = repository;
            _mapper = mapper;
            _exercicioService = exercicioService;
        }
        private async Task<Treino> ObterTreino(int id)
        {
            var treino = await _repository.ObterPorId(id);
            if (treino == null)
                throw new TreinoNotFound();

            return treino;
        }

        public async Task<TreinoResponseDTO> Criar(TreinoCreateDTO novoTreino)
        {
            var treino = _mapper.Map<Treino>(novoTreino);
            await _repository.Adicionar(treino);
            return _mapper.Map<TreinoResponseDTO>(treino);
        }

        public async Task<TreinoResponseDTO> ObterPorId(int id)
        {
            var treino = ObterTreino(id);
            return _mapper.Map<TreinoResponseDTO>(treino);
        }

        public async Task<IReadOnlyCollection<TreinoResponseDTO>> ObterTodosPorUsuarioId(int usuarioId)
        {
            var treinos = await _repository.ObterTodosPorUsuario(usuarioId);
            return _mapper.Map<List<TreinoResponseDTO>>(treinos);
        }
        public async Task Remover(int id)
        {
            var treino = await ObterTreino(id);
            await _repository.Remover(treino);
        }

        public async Task Atualizar(TreinoUpdateDTO treinoAtualizado, int id)
        {
            var treinoBanco = await ObterTreino(id);
            if (treinoAtualizado.Nome == null)
                throw new ArgumentException("Nenhum valor para atualização foi inserido.");
            else
            {
                treinoBanco.AlterarNome(treinoAtualizado.Nome);
                await _repository.Atualizar(treinoBanco);
            }
        }
    }
}
