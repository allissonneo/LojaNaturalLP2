using System.Linq;

namespace LojaNatural.Models;

public class Venda
{
    public Cliente Cliente { get; set; }
    public List<Produto> Produtos { get; set; }
    public double ValorTotal { get; set; }
    public string FormaPagamento { get; set; }

    public Venda(Cliente cliente, string formaPagamento)
    {
        Cliente = cliente;
        FormaPagamento = formaPagamento;
        Produtos = new List<Produto>();
        ValorTotal = 0;
    }

    public void CalcularTotal()
    {
        ValorTotal = Produtos.Sum(p => p.Preco);
    }
}