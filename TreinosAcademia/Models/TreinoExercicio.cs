namespace TreinosAcademia.Models
{
    public class TreinoExercicio
    {
        public int Id { get; private set; }
        public int ExercicioId { get; private set; }
        public Exercicio Exercicio { get; private set; }
        public int TreinoId { get; private set; }
        public Treino Treino { get; private set; }
        public int Series { get; private set; }
        public int Repeticoes { get; private set;  }

        public TreinoExercicio(int exercicioId, int treinoId, int series, int repeticoes)
        {
            if (exercicioId <= 0)
                throw new ArgumentException("ID do Exercício deve ser maior que 0.");

            if (treinoId <= 0)
                throw new ArgumentException("ID do Treino deve ser maior que 0.");

            if (series <= 0)
                throw new ArgumentException("Quantidade de séries deve ser maior que 0.");

            if (repeticoes <= 0)
                throw new ArgumentException("Quantidade de repetições deve ser maior que 0.");

            ExercicioId = exercicioId;
            TreinoId = treinoId;
            Series = series;
            Repeticoes = repeticoes;
        }

        public void AlterarQuantidadeSeries(int novaQuantidade)
        {
            if (novaQuantidade <= 0)
                throw new ArgumentException("Quantidade de séries deve ser maior que 0.");

            Series = novaQuantidade;
        }

        public void AlterarQuantidadeRepeticoes(int novaQuantidade)
        {
            if (novaQuantidade <= 0)
                throw new ArgumentException("Quantidade de repetições deve ser maior que 0.");

            Repeticoes = novaQuantidade;
        }
    }
}
