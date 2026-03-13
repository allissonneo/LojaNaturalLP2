using LojaNatural.Models;

namespace LojaNatural.Services;

public class ProdutoService
{
    public List<Produto> Produtos { get; set; } = new List<Produto>();

    public void CadastrarProduto(string nome, double preco, string categoria, string tipoVenda)
    {
        Produto produto = new Produto(nome, preco, categoria, tipoVenda);
        Produtos.Add(produto);

        Console.WriteLine("Produto cadastrado com sucesso!");
    }

    public void ListarProdutos()
    {
        if (Produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        for (int i = 0; i < Produtos.Count; i++)
        {
            var p = Produtos[i];
            Console.WriteLine($"{i + 1} - {p.Nome} | R$ {p.Preco} | {p.Categoria}");
        }
    }
}