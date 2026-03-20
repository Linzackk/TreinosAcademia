namespace TreinosAcademia.Models
{
    public enum RegiaoMuscular
    {
        Peito,
        Costas,
        Pernas,
        Ombro,
        Biceps,
        Triceps,
        Abdomen,
    }
    public class Exercicio
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public RegiaoMuscular Regiao { get; private set; }

        public Exercicio(string nome, RegiaoMuscular regiao)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentException("Nome do exercício não pode estar vazio.");

            Nome = nome;
            Regiao = regiao;
        }

        public void AlterarNome(string novoNome)
        {
            if (string.IsNullOrEmpty(novoNome))
                throw new ArgumentException("Nome do exercício não pode estar vazio.");

            Nome = novoNome;
        }

        public void AlterarRegiao(RegiaoMuscular novaRegiao)
        {
            Regiao = novaRegiao;
        }
    }
}
