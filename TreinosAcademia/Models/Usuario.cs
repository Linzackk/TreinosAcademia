namespace TreinosAcademia.Models
{
    public class Usuario
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }

        private readonly List<Treino> _treinos = new List<Treino>();
        public IReadOnlyCollection<Treino> Treinos => _treinos.AsReadOnly();

        public Usuario(string nome, string email, string senha)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome não pode estar vazio.");

            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("Email não pode estar vazio.");

            if (string.IsNullOrEmpty(senha))
                throw new ArgumentException("Senha não pode estar vazia.");

            if (senha.Length <= 5)
                throw new ArgumentException("Senha curta demais.");

            Nome = nome;
            Email = email;
            Senha = senha;
        }

        public void AlterarNome(string novoNome)
        {
            if (string.IsNullOrEmpty(novoNome))
                throw new ArgumentException("Novo Nome não pode estar vazio.");

            Nome = novoNome;
        }

        public void AlterarEmail(string novoEmail)
        {
            if (string.IsNullOrEmpty(novoEmail))
                throw new ArgumentException("Novo E-mail não pode estar vazio.");

            Email = novoEmail;
        }

        public void AlterarSenha(string novaSenha)
        {
            if (novaSenha == Senha)
                throw new ArgumentException("A Nova senha deve ser diferente da anterior.");

            if (string.IsNullOrEmpty(novaSenha))
                throw new ArgumentException("Nova Senha não pode estar vazia.");

            if (novaSenha.Length <= 5)
                throw new ArgumentException("Senha curta demais.");

            Senha = novaSenha;
        }
    }
}
