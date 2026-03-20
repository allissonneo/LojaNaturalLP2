using LojaNatural.Models;
using LojaNatural.Utils;

namespace LojaNatural.Services
{
    public class VendaService
    {
        public List<Venda> Vendas { get; set; }

        public VendaService()
        {
            Vendas = DataStore.CarregarVendas();
        }

        public void RealizarVenda(Cliente cliente, Funcionario funcionario, List<Produto> produtos, string formaPagamento)
        {
            Venda venda = new Venda(cliente, funcionario, produtos, formaPagamento);
            Vendas.Add(venda);
            DataStore.SalvarVendas(Vendas);

            Console.WriteLine("Venda realizada com sucesso!");
        }

        public void ListarVendas()
        {
            if (Vendas.Count == 0)
            {
                Console.WriteLine("Nenhuma venda cadastrada.");
                return;
            }

            for (int i = 0; i < Vendas.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Vendas[i]}");
            }
        }

        public List<Venda> ObterVendasPorAnoEMes(int ano, int mes)
        {
            return Vendas
                .Where(v => v.Data.Year == ano && v.Data.Month == mes)
                .ToList();
        }

        public void CancelarVenda(int indice)
        {
            if (indice < 0 || indice >= Vendas.Count)
            {
                Console.WriteLine("Venda inválida.");
                return;
            }

            Vendas.RemoveAt(indice);
            DataStore.SalvarVendas(Vendas);

            Console.WriteLine("Venda cancelada com sucesso!");
        }
    }
}