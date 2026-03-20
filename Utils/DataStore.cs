using System.Text.Json;
using LojaNatural.Models;

namespace LojaNatural.Utils
{
    public static class DataStore
    {
        private static readonly string pastaDados = "Data";

        public static List<Produto> CarregarProdutos()
        {
            string caminho = Path.Combine(pastaDados, "produtos.json");
            if (!File.Exists(caminho)) return new List<Produto>();

            string json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<List<Produto>>(json) ?? new List<Produto>();
        }

        public static void SalvarProdutos(List<Produto> produtos)
        {
            Directory.CreateDirectory(pastaDados);
            string caminho = Path.Combine(pastaDados, "produtos.json");
            string json = JsonSerializer.Serialize(produtos, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminho, json);
        }

        public static List<Cliente> CarregarClientes()
        {
            string caminho = Path.Combine(pastaDados, "clientes.json");
            if (!File.Exists(caminho)) return new List<Cliente>();

            string json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<List<Cliente>>(json) ?? new List<Cliente>();
        }

        public static void SalvarClientes(List<Cliente> clientes)
        {
            Directory.CreateDirectory(pastaDados);
            string caminho = Path.Combine(pastaDados, "clientes.json");
            string json = JsonSerializer.Serialize(clientes, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminho, json);
        }

        public static List<Funcionario> CarregarFuncionarios()
        {
            string caminho = Path.Combine(pastaDados, "funcionarios.json");
            if (!File.Exists(caminho)) return new List<Funcionario>();

            string json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<List<Funcionario>>(json) ?? new List<Funcionario>();
        }

        public static void SalvarFuncionarios(List<Funcionario> funcionarios)
        {
            Directory.CreateDirectory(pastaDados);
            string caminho = Path.Combine(pastaDados, "funcionarios.json");
            string json = JsonSerializer.Serialize(funcionarios, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminho, json);
        }

        public static List<Venda> CarregarVendas()
        {
            string caminho = Path.Combine(pastaDados, "vendas.json");
            if (!File.Exists(caminho)) return new List<Venda>();

            string json = File.ReadAllText(caminho);
            return JsonSerializer.Deserialize<List<Venda>>(json) ?? new List<Venda>();
        }

        public static void SalvarVendas(List<Venda> vendas)
        {
            Directory.CreateDirectory(pastaDados);
            string caminho = Path.Combine(pastaDados, "vendas.json");
            string json = JsonSerializer.Serialize(vendas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(caminho, json);
        }
    }
}