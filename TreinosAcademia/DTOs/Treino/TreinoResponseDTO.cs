using TreinosAcademia.DTOs.TreinoExercicio;
using TreinosAcademia.Models;

namespace TreinosAcademia.DTOs.Treino
{
    public class TreinoResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string UsuarioNome { get; set; }
        public IReadOnlyCollection<TreinoExercicioResponseDTO> Exercicios { get; set; }
    }
}
