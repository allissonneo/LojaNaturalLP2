namespace LojaNatural.Models;

public class Cliente
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }

    public List<Venda> HistoricoCompras { get; set; }

    public Cliente(string nome, string email)
    {
        Nome = nome;
        Email = email;
        Login = "";
        Senha = "";
        HistoricoCompras = new List<Venda>();
    }
}