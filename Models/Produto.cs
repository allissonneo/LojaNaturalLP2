namespace LojaNatural.Models;

public class Produto
{
    public string Nome { get; set; }
    public double Preco { get; set; }
    public string Categoria { get; set; }
    public string TipoVenda { get; set; } // Unidade ou Kg
    public List<string> Tags { get; set; }

    public Produto(string nome, double preco, string categoria, string tipoVenda)
    {
        Nome = nome;
        Preco = preco;
        Categoria = categoria;
        TipoVenda = tipoVenda;
        Tags = new List<string>();
    }
}