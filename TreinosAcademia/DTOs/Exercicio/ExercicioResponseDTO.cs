using TreinosAcademia.Models;

namespace TreinosAcademia.DTOs.Exercicio
{
    public class ExercicioResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public RegiaoMuscular Regiao { get; set; }
    }
}
