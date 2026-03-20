namespace TreinosAcademia.Middleware
{
    public class TreinoExercicioNotFound : Exception
    {
        public TreinoExercicioNotFound()
            : base("Treino Exercicio não foi encontrado.") { }
    }
}
