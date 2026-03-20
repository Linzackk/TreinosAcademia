using Microsoft.EntityFrameworkCore;
using TreinosAcademia.Data;
using TreinosAcademia.Models;
using TreinosAcademia.Repositories.Interfaces;

namespace TreinosAcademia.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterPorId(int id)
        {
            var usuario =  await _context.Usuarios.FindAsync(id);
            return usuario;
        }

        public async Task<IReadOnlyCollection<Usuario>> ObterTodos()
        {
            var usuarios = await _context.Usuarios.AsNoTracking().ToListAsync();
            return usuarios;
        }

        public async Task Adicionar(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
        public async Task Remover(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Usuario usuario)
        {
            await _context.SaveChangesAsync();
        }
    }
}
