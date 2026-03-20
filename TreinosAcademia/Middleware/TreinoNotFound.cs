namespace TreinosAcademia.Middleware
{
    public class TreinoNotFound : Exception
    {
        public TreinoNotFound()
            : base("Usuário não encontrado") { }
    }
}
