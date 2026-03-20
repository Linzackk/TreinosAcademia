namespace TreinosAcademia.Models
{
    public class Treino
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int UsuarioId { get; private set; }
        public Usuario Usuario { get; private set; }

        private List<TreinoExercicio> _treinoExercicio = new List<TreinoExercicio>();
        public IReadOnlyCollection<TreinoExercicio> TreinoExercicio => _treinoExercicio.AsReadOnly();

        public Treino(string nome, int usuarioId)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome do Treino não pode estar vazio.");

            if (usuarioId <= 0)
                throw new ArgumentException("ID do usuario deve ser maior que 0.");
            Nome = nome;
            UsuarioId = usuarioId;
        }

        public void AlterarNome(string novoNome)
        {
            if (string.IsNullOrEmpty(novoNome))
                throw new ArgumentException("Novo nome do Treino não pode estar vazio.");

            Nome = novoNome;
        }
    }
}
