using Microsoft.EntityFrameworkCore;
using TreinosAcademia.Data;
using TreinosAcademia.Models;
using TreinosAcademia.Repositories.Interfaces;

namespace TreinosAcademia.Repositories
{
    public class TreinoRepository : ITreinoRepository
    {
        private readonly AppDbContext _context;
        public TreinoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Treino> ObterPorId(int id)
        {
            var treino = await _context.Treinos
                .AsNoTracking()
                .Include(t => t.Usuario)
                .Include(t => t.TreinoExercicio)
                    .ThenInclude(te => te.Exercicio)
                .FirstOrDefaultAsync(t => t.Id == id);
            return treino;
        }

        public async Task<IReadOnlyCollection<Treino>> ObterTodos()
        {
            var treinos = await _context.Treinos
                .AsNoTracking()
                .Include(t => t.Usuario)
                .Include(t => t.TreinoExercicio)
                    .ThenInclude(te => te.Exercicio)
                .ToListAsync();
            return treinos;
        }

        public async Task<IReadOnlyCollection<Treino>> ObterTodosPorUsuario(int usuarioId)
        {
            var treinosUsuario = await _context.Treinos
                .AsNoTracking()
                .Include(t => t.TreinoExercicio)
                    .ThenInclude(te => te.Exercicio)
                .Where(t => t.UsuarioId == usuarioId)
                .ToListAsync();
            return treinosUsuario;
        }

        public async Task Remover(Treino treino)
        {
            _context.Treinos.Remove(treino);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Treino treino)
        {
            _context.Treinos.Update(treino);
            await _context.SaveChangesAsync();
        }

        public async Task Adicionar(Treino treino)
        {
            await _context.Treinos.AddAsync(treino);
            await _context.SaveChangesAsync();
        }
    }
}
