using Microsoft.EntityFrameworkCore;
using TreinosAcademia.Models;

namespace TreinosAcademia.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<TreinoExercicio> TreinosExercicios { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Treino>()
                .HasMany(t => t.TreinoExercicio)
                .WithOne(te => te.Treino)
                .HasForeignKey(te => te.TreinoId);

            modelBuilder.Entity<TreinoExercicio>()
                .HasOne(te => te.Exercicio)
                .WithMany()
                .HasForeignKey(te => te.ExercicioId);

        }
    }
}
