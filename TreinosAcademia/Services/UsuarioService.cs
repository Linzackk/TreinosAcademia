using AutoMapper;
using TreinosAcademia.DTOs.Usuario;
using TreinosAcademia.Middleware;
using TreinosAcademia.Models;
using TreinosAcademia.Repositories.Interfaces;
using TreinosAcademia.Services.Interfaces;

namespace TreinosAcademia.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UsuarioResponseDTO> CriarUsuario(UsuarioCreateDTO novoUsuario)
        {
            var usuario = _mapper.Map<Usuario>(novoUsuario);
            await _repository.Adicionar(usuario);
            return _mapper.Map<UsuarioResponseDTO>(usuario);
        }
        public async Task<UsuarioResponseDTO> ObterPorId(int id)
        {
            var usuario = await ObterUsuarioPorId(id);
            return _mapper.Map<UsuarioResponseDTO>(usuario);
        }
        public async Task<IReadOnlyCollection<UsuarioResponseDTO>> ObterTodos()
        {
            var usuarios = await _repository.ObterTodos();
            var response = new List<UsuarioResponseDTO>();
            return _mapper.Map<List<UsuarioResponseDTO>>(usuarios);
        }
        public async Task Atualizar(UsuarioUpdateDTO usuarioAtualizado, int id)
        {
            if (usuarioAtualizado.Nome == null && usuarioAtualizado.Email == null && usuarioAtualizado.Senha == null)
                throw new ArgumentException("Nenhuma informação foi inserida para alteração.");

            var usuarioBanco = await ObterUsuarioPorId(id);

            if (usuarioAtualizado.Nome != null)
                usuarioBanco.AlterarNome(usuarioAtualizado.Nome);

            if (usuarioAtualizado.Email != null)
                usuarioBanco.AlterarEmail(usuarioAtualizado.Email);

            if (usuarioAtualizado.Senha != null)
                usuarioBanco.AlterarSenha(usuarioAtualizado.Senha);

            await _repository.Atualizar(usuarioBanco);
        }
        public async Task Remover(int id)
        {
            var usuario = await ObterUsuarioPorId(id);
            await _repository.Remover(usuario);
        }

        private async Task<Usuario> ObterUsuarioPorId(int id)
        {
            var usuarioBanco = await _repository.ObterPorId(id);
            if (usuarioBanco == null)
                throw new UsuarioNotFound();
            return usuarioBanco;
        }
    }
}
