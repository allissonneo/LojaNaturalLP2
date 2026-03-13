using LojaNatural.Models;

namespace LojaNatural.Services;

public class VendaService
{
    public List<Venda> Vendas { get; set; } = new List<Venda>();

    public void RealizarVenda(Cliente cliente, List<Produto> produtos, string formaPagamento)
    {
        Venda venda = new Venda(cliente, formaPagamento);

        foreach (var produto in produtos)
        {
            venda.Produtos.Add(produto);
        }

        venda.CalcularTotal();

        Vendas.Add(venda);
        cliente.HistoricoCompras.Add(venda);

        Console.WriteLine("\nVenda realizada com sucesso!");
        Console.WriteLine($"Cliente: {cliente.Nome}");
        Console.WriteLine($"Forma de pagamento: {formaPagamento}");
        Console.WriteLine($"Total: R$ {venda.ValorTotal:F2}");
    }

    public void ListarVendas()
    {
        if (Vendas.Count == 0)
        {
            Console.WriteLine("Nenhuma venda realizada.");
            return;
        }

        for (int i = 0; i < Vendas.Count; i++)
        {
            var venda = Vendas[i];
            Console.WriteLine($"\nVenda {i + 1}");
            Console.WriteLine($"Cliente: {venda.Cliente.Nome}");
            Console.WriteLine($"Forma de pagamento: {venda.FormaPagamento}");
            Console.WriteLine($"Total: R$ {venda.ValorTotal:F2}");
            Console.WriteLine("Produtos:");

            foreach (var produto in venda.Produtos)
            {
                Console.WriteLine($"- {produto.Nome} | R$ {produto.Preco:F2}");
            }
        }
    }
}