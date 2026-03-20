namespace LojaNatural.Models
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public List<Venda> HistoricoCompras { get; set; }

        public Cliente()
        {
            Nome = string.Empty;
            Email = string.Empty;
            Login = string.Empty;
            Senha = string.Empty;
            HistoricoCompras = new List<Venda>();
        }

        public Cliente(string nome, string email)
        {
            Nome = nome;
            Email = email;
            Login = string.Empty;
            Senha = string.Empty;
            HistoricoCompras = new List<Venda>();
        }

        public override string ToString()
        {
            return $"{Nome} - {Email}";
        }
    }
}