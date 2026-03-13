namespace LojaNatural.Models;

public class Loja
{
    public string Nome { get; set; }
    public string Endereco { get; set; }

    public List<Produto> Produtos { get; set; }
    public List<Funcionario> Funcionarios { get; set; }

    public Loja(string nome, string endereco)
    {
        Nome = nome;
        Endereco = endereco;

        Produtos = new List<Produto>();
        Funcionarios = new List<Funcionario>();
    }
}