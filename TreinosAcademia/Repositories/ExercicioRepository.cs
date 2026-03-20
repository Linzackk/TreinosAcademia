using Microsoft.EntityFrameworkCore;
using TreinosAcademia.Data;
using TreinosAcademia.Models;
using TreinosAcademia.Repositories.Interfaces;

namespace TreinosAcademia.Repositories
{
    public class ExercicioRepository : IExercicioRepository
    {
        private readonly AppDbContext _context;
        public ExercicioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(Exercicio exercicio)
        {
            await _context.Exercicios.AddAsync(exercicio);
            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Exercicio>> ObterTodos()
        {
            var exercicios = await _context.Exercicios.AsNoTracking().ToListAsync();
            return exercicios;
        }

        public async Task<Exercicio> ObterPorId(int id)
        {
            var exercicio = await _context.Exercicios.FindAsync(id);
            return exercicio;
        }

        public async Task Remover(Exercicio exercicio)
        {
            _context.Exercicios.Remove(exercicio);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Exercicio exercicio)
        {
            _context.Exercicios.Update(exercicio);
            await _context.SaveChangesAsync();
        }
    }
}
