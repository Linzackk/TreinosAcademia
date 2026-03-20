using TreinosAcademia.DTOs.TreinoExercicio;

namespace TreinosAcademia.DTOs.Treino
{
    public class TreinoCreateDTO
    {
        public string Nome { get; set; }
        public int UsuarioId { get; set; }
        public List<TreinoExercicioCreateDTO> Exercicios { get; set; } = new();
    }
}
