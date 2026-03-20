namespace LojaNatural.Models
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public List<Atribuicao> Atribuicoes { get; set; }

        public Funcionario()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Atribuicoes = new List<Atribuicao>();
        }

        public Funcionario(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Atribuicoes = new List<Atribuicao>();
        }

        public bool PossuiAtribuicao(Atribuicao atribuicao)
        {
            return Atribuicoes.Contains(atribuicao);
        }

        public override string ToString()
        {
            return $"{Nome} - {Email} - [{string.Join(", ", Atribuicoes)}]";
        }
    }
}