namespace TreinosAcademia.Middleware
{
    public class UsuarioNotFound :  Exception
    {
        public UsuarioNotFound()
            : base("Usuário não encontrado") { }
    }
}
