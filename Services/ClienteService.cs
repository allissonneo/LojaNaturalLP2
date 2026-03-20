using LojaNatural.Models;
using LojaNatural.Utils;

namespace LojaNatural.Services;

public class ClienteService
{
    public List<Cliente> Clientes { get; set; } = new List<Cliente>();

    public ClienteService()
    {
        Clientes = DataStore.CarregarClientes();

        if (Clientes.Count == 0)
        {
            Clientes.Add(new Cliente("Cliente Base", "cliente@base.com"));
            DataStore.SalvarClientes(Clientes);
        }
    }

    public void CadastrarCliente(string nome, string email)
    {
        Cliente cliente = new Cliente(nome, email);
        Clientes.Add(cliente);

        Console.WriteLine("Cliente cadastrado!");
    }

    public void ListarClientes()
    {
        if (Clientes.Count == 0)
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            return;
        }

        for (int i = 0; i < Clientes.Count; i++)
        {
            var c = Clientes[i];
            Console.WriteLine($"{i + 1} - {c.Nome} | {c.Email}");
        }
    }
    public void ExcluirCliente(int indice)
    {
        if (indice < 0 || indice >= Clientes.Count)
        {
            Console.WriteLine("Cliente inválido.");
            return;
        }

        Clientes.RemoveAt(indice);
        DataStore.SalvarClientes(Clientes);

        Console.WriteLine("Cliente excluído com sucesso!");
    }
}