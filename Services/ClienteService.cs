using LojaNatural.Models;

namespace LojaNatural.Services;

public class ClienteService
{
    public List<Cliente> Clientes { get; set; } = new List<Cliente>();

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
}