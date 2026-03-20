using Microsoft.EntityFrameworkCore;
using TreinosAcademia.Data;
using TreinosAcademia.Models;
using TreinosAcademia.Repositories.Interfaces;

namespace TreinosAcademia.Repositories
{
    public class TreinoExercicioRepository : ITreinoExercicioRepository
    {
        private readonly AppDbContext _context;
        public TreinoExercicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(TreinoExercicio treinoExercicio)
        {
            await _context.TreinosExercicios.AddAsync(treinoExercicio);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<TreinoExercicio>> ObterPorTreinoId(int treinoId)
        {
            var treinoExercicios = await _context.TreinosExercicios
                .AsNoTracking()
                .Include(te => te.Exercicio)
                .Where(te => te.TreinoId == treinoId)
                .ToListAsync();
            return treinoExercicios;
        }

        public async Task Remover(TreinoExercicio treinoExercicio)
        {
            _context.TreinosExercicios.Remove(treinoExercicio);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(TreinoExercicio treinoExercicio)
        {
            _context.TreinosExercicios.Update(treinoExercicio);
            await _context.SaveChangesAsync();
        }
    }
}
