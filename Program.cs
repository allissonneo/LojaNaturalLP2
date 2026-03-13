using LojaNatural.Models;
using LojaNatural.Services;

ProdutoService produtoService = new ProdutoService();
ClienteService clienteService = new ClienteService();
VendaService vendaService = new VendaService();

bool rodando = true;

while (rodando)
{
    Console.WriteLine("\n1 - Cadastrar Produto");
    Console.WriteLine("2 - Listar Produtos");
    Console.WriteLine("3 - Cadastrar Cliente");
    Console.WriteLine("4 - Listar Clientes");
    Console.WriteLine("5 - Realizar Venda");
    Console.WriteLine("6 - Listar Vendas");
    Console.WriteLine("0 - Sair");

    Console.Write("Escolha uma opção: ");
    string? opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Nome do produto: ");
            string? nomeProduto = Console.ReadLine();

            Console.Write("Preço: ");
            double preco = double.Parse(Console.ReadLine()!);

            produtoService.CadastrarProduto(nomeProduto!, preco, "Natural", "Unidade");
            break;

        case "2":
            produtoService.ListarProdutos();
            break;

        case "3":
            Console.Write("Nome do cliente: ");
            string? nomeCliente = Console.ReadLine();

            Console.Write("Email: ");
            string? email = Console.ReadLine();

            clienteService.CadastrarCliente(nomeCliente!, email!);
            break;

        case "4":
            clienteService.ListarClientes();
            break;

        case "5":
            if (clienteService.Clientes.Count == 0)
            {
                Console.WriteLine("Cadastre pelo menos um cliente antes de vender.");
                break;
            }

            if (produtoService.Produtos.Count == 0)
            {
                Console.WriteLine("Cadastre pelo menos um produto antes de vender.");
                break;
            }

            Console.WriteLine("\nClientes disponíveis:");
            clienteService.ListarClientes();
            Console.Write("Escolha o número do cliente: ");
            int indiceCliente = int.Parse(Console.ReadLine()!) - 1;

            if (indiceCliente < 0 || indiceCliente >= clienteService.Clientes.Count)
            {
                Console.WriteLine("Cliente inválido.");
                break;
            }

            Cliente clienteSelecionado = clienteService.Clientes[indiceCliente];
            List<Produto> produtosSelecionados = new List<Produto>();

            string continuar = "s";

            while (continuar.ToLower() == "s")
            {
                Console.WriteLine("\nProdutos disponíveis:");
                produtoService.ListarProdutos();
                Console.Write("Escolha o número do produto: ");
                int indiceProduto = int.Parse(Console.ReadLine()!) - 1;

                if (indiceProduto < 0 || indiceProduto >= produtoService.Produtos.Count)
                {
                    Console.WriteLine("Produto inválido.");
                }
                else
                {
                    produtosSelecionados.Add(produtoService.Produtos[indiceProduto]);
                    Console.WriteLine("Produto adicionado à venda.");
                }

                Console.Write("Deseja adicionar mais produtos? (s/n): ");
                continuar = Console.ReadLine()!;
            }

            if (produtosSelecionados.Count == 0)
            {
                Console.WriteLine("Nenhum produto foi selecionado.");
                break;
            }

            Console.Write("Forma de pagamento: ");
            string? formaPagamento = Console.ReadLine();

            vendaService.RealizarVenda(clienteSelecionado, produtosSelecionados, formaPagamento!);
            break;

        case "6":
            vendaService.ListarVendas();
            break;

        case "0":
            rodando = false;
            break;

        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}