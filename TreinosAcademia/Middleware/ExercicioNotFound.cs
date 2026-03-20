namespace TreinosAcademia.Middleware
{
    public class ExercicioNotFound : Exception
    {
        public ExercicioNotFound()
            : base("Usuário não encontrado") { }
    }
}
