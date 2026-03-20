using LojaNatural.Models;
using LojaNatural.Services;
using LojaNatural.Utils;

ProdutoService produtoService = new ProdutoService();
ClienteService clienteService = new ClienteService();
FuncionarioService funcionarioService = new FuncionarioService();
VendaService vendaService = new VendaService();

bool rodando = true;

while (rodando)
{
    Console.WriteLine("\n=== MENU PRINCIPAL ===");
    Console.WriteLine("1 - Produtos");
    Console.WriteLine("2 - Clientes");
    Console.WriteLine("3 - Funcionários");
    Console.WriteLine("4 - Vendas");
    Console.WriteLine("5 - Relatórios");
    Console.WriteLine("0 - Sair");

    string opcao = ConsoleHelper.LerTextoObrigatorio("Escolha uma opção: ");

    switch (opcao)
    {
        case "1":
            MenuProdutos();
            break;
        case "2":
            MenuClientes();
            break;
        case "3":
            MenuFuncionarios();
            break;
        case "4":
            MenuVendas();
            break;
        case "5":
            MenuRelatorios();
            break;
        case "0":
            rodando = false;
            break;
        default:
            Console.WriteLine("Opção inválida.");
            break;
    }
}

void MenuProdutos()
{
    bool voltar = false;

    while (!voltar)
    {
        Console.WriteLine("\n=== MENU PRODUTOS ===");
        Console.WriteLine("1 - Cadastrar Produto");
        Console.WriteLine("2 - Listar Produtos");
        Console.WriteLine("3 - Excluir Produto");
        Console.WriteLine("0 - Voltar");

        string opcao = ConsoleHelper.LerTextoObrigatorio("Escolha uma opção: ");

        switch (opcao)
        {
            case "1":
                string nome = ConsoleHelper.LerTextoObrigatorio("Nome do produto: ");
                double preco = ConsoleHelper.LerDoublePositivo("Preço: ");
                produtoService.CadastrarProduto(nome, preco, "Natural", "Unidade");
                break;

            case "2":
                produtoService.ListarProdutos();
                break;

            case "3":
                ExcluirProdutoPeloMenu();
                break;

            case "0":
                voltar = true;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    void ExcluirProdutoPeloMenu()
    {
        if (produtoService.Produtos.Count == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("\nProdutos disponíveis:");
        produtoService.ListarProdutos();

        int indice = ConsoleHelper.LerIntPositivo("Escolha o número do produto para excluir: ") - 1;

        if (indice < 0 || indice >= produtoService.Produtos.Count)
        {
            Console.WriteLine("Produto inválido.");
            return;
        }

        string confirmacao = ConsoleHelper.LerTextoObrigatorio("Tem certeza que deseja excluir? (s/n): ");

        if (confirmacao.ToLower() == "s")
        {
            produtoService.ExcluirProduto(indice);
        }
        else
        {
            Console.WriteLine("Exclusão cancelada.");
        }
    }
}

void MenuClientes()
{
    bool voltar = false;

    while (!voltar)
    {
        Console.WriteLine("\n=== MENU CLIENTES ===");
        Console.WriteLine("1 - Cadastrar Cliente");
        Console.WriteLine("2 - Listar Clientes");
        Console.WriteLine("3 - Excluir Cliente");
        Console.WriteLine("0 - Voltar");

        string opcao = ConsoleHelper.LerTextoObrigatorio("Escolha uma opção: ");

        switch (opcao)
        {
            case "1":
                string nome = ConsoleHelper.LerTextoObrigatorio("Nome do cliente: ");
                string email = ConsoleHelper.LerEmailValido("Email: ");
                clienteService.CadastrarCliente(nome, email);
                break;

            case "2":
                clienteService.ListarClientes();
                break;

            case "3":
                ExcluirClientePeloMenu();
                break;

            case "0":
                voltar = true;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    void ExcluirClientePeloMenu()
    {
        if (clienteService.Clientes.Count == 0)
        {
            Console.WriteLine("Nenhum cliente cadastrado.");
            return;
        }

        Console.WriteLine("\nClientes disponíveis:");
        clienteService.ListarClientes();

        int indice = ConsoleHelper.LerIntPositivo("Escolha o número do cliente para excluir: ") - 1;

        if (indice < 0 || indice >= clienteService.Clientes.Count)
        {
            Console.WriteLine("Cliente inválido.");
            return;
        }

        string confirmacao = ConsoleHelper.LerTextoObrigatorio("Tem certeza que deseja excluir? (s/n): ");

        if (confirmacao.ToLower() == "s")
        {
            clienteService.ExcluirCliente(indice);
        }
        else
        {
            Console.WriteLine("Exclusão cancelada.");
        }
    }
}

void MenuFuncionarios()
{
    bool voltar = false;

    while (!voltar)
    {
        Console.WriteLine("\n=== MENU FUNCIONÁRIOS ===");
        Console.WriteLine("1 - Cadastrar Funcionário");
        Console.WriteLine("2 - Listar Funcionários");
        Console.WriteLine("3 - Excluir Funcionário");
        Console.WriteLine("0 - Voltar");

        string opcao = ConsoleHelper.LerTextoObrigatorio("Escolha uma opção: ");

        switch (opcao)
        {
            case "1":
                string nome = ConsoleHelper.LerTextoObrigatorio("Nome do funcionário: ");
                string email = ConsoleHelper.LerEmailValido("Email do funcionário: ");
                List<Atribuicao> atribuicoes = LerAtribuicoes();

                funcionarioService.CadastrarFuncionario(nome, email, atribuicoes);
                break;

            case "2":
                funcionarioService.ListarFuncionarios();
                break;

            case "3":
                ExcluirFuncionarioPeloMenu();
                break;

            case "0":
                voltar = true;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
    void ExcluirFuncionarioPeloMenu()
    {
        if (funcionarioService.Funcionarios.Count == 0)
        {
            Console.WriteLine("Nenhum funcionário cadastrado.");
            return;
        }

        Console.WriteLine("\nFuncionários disponíveis:");
        funcionarioService.ListarFuncionarios();

        int indice = ConsoleHelper.LerIntPositivo("Escolha o número do funcionário para excluir: ") - 1;

        if (indice < 0 || indice >= funcionarioService.Funcionarios.Count)
        {
            Console.WriteLine("Funcionário inválido.");
            return;
        }

        string confirmacao = ConsoleHelper.LerTextoObrigatorio("Tem certeza que deseja excluir? (s/n): ");

        if (confirmacao.ToLower() == "s" || confirmacao.ToLower() == "sim" || confirmacao.ToLower() == "sair")
        {
            funcionarioService.ExcluirFuncionario(indice);
        }
        else
        {
            Console.WriteLine("Exclusão cancelada.");
        }
    }
}

void MenuRelatorios()
{
    if (funcionarioService.Funcionarios.Count == 0)
    {
        Console.WriteLine("Nenhum funcionário cadastrado.");
        return;
    }

    Console.WriteLine("\nFuncionários disponíveis:");
    funcionarioService.ListarFuncionarios();

    int indiceFuncionario = ConsoleHelper.LerIntPositivo("Escolha o número do funcionário: ") - 1;

    if (indiceFuncionario < 0 || indiceFuncionario >= funcionarioService.Funcionarios.Count)
    {
        Console.WriteLine("Funcionário inválido.");
        return;
    }

    Funcionario funcionario = funcionarioService.Funcionarios[indiceFuncionario];

    if (!funcionario.PossuiAtribuicao(Atribuicao.Gerente))
    {
        Console.WriteLine("Acesso negado. Apenas gerente pode visualizar relatórios.");
        return;
    }

    int ano = ConsoleHelper.LerIntPositivo("Ano: ");
    int mes = ConsoleHelper.LerIntPositivo("Mês: ");

    if (mes < 1 || mes > 12)
    {
        Console.WriteLine("Mês inválido.");
        return;
    }

    var vendasFiltradas = vendaService.ObterVendasPorAnoEMes(ano, mes);

    if (vendasFiltradas.Count == 0)
    {
        Console.WriteLine("Nenhuma venda encontrada para o período.");
        return;
    }

    Console.WriteLine($"\n=== RELATÓRIO {mes:D2}/{ano} ===");

    double total = 0;

    foreach (var venda in vendasFiltradas)
    {
        Console.WriteLine(venda);
        total += venda.CalcularTotal();
    }

    Console.WriteLine($"Total vendido no período: R$ {total:F2}");
}

List<Atribuicao> LerAtribuicoes()
{
    Console.WriteLine("Atribuições disponíveis:");
    Console.WriteLine("1 - Caixa");
    Console.WriteLine("2 - Repositor");
    Console.WriteLine("3 - Gerente");
    Console.WriteLine("4 - Entregador");

    string entrada = ConsoleHelper.LerTextoObrigatorio("Digite os números separados por vírgula: ");
    string[] partes = entrada.Split(',');

    List<Atribuicao> atribuicoes = new List<Atribuicao>();

    foreach (string parte in partes)
    {
        switch (parte.Trim())
        {
            case "1":
                if (!atribuicoes.Contains(Atribuicao.Caixa))
                    atribuicoes.Add(Atribuicao.Caixa);
                break;
            case "2":
                if (!atribuicoes.Contains(Atribuicao.Repositor))
                    atribuicoes.Add(Atribuicao.Repositor);
                break;
            case "3":
                if (!atribuicoes.Contains(Atribuicao.Gerente))
                    atribuicoes.Add(Atribuicao.Gerente);
                break;
            case "4":
                if (!atribuicoes.Contains(Atribuicao.Entregador))
                    atribuicoes.Add(Atribuicao.Entregador);
                break;
        }
    }

    return atribuicoes;
}
void MenuVendas()
{
    bool voltar = false;

    while (!voltar)
    {
        Console.WriteLine("\n=== MENU VENDAS ===");
        Console.WriteLine("1 - Realizar Venda");
        Console.WriteLine("2 - Listar Vendas");
        Console.WriteLine("3 - Cancelar Venda");
        Console.WriteLine("0 - Voltar");

        string opcao = ConsoleHelper.LerTextoObrigatorio("Escolha uma opção: ");

        switch (opcao)
        {
            case "1":
                RealizarVendaPeloMenu();
                break;

            case "2":
                vendaService.ListarVendas();
                break;

            case "3":
                CancelarVendaPeloMenu();
                break;

            case "0":
                voltar = true;
                break;

            default:
                Console.WriteLine("Opção inválida.");
                break;
        }
    }
}

void RealizarVendaPeloMenu()
{
    if (clienteService.Clientes.Count == 0)
    {
        Console.WriteLine("Cadastre pelo menos um cliente antes de vender.");
        return;
    }

    if (produtoService.Produtos.Count == 0)
    {
        Console.WriteLine("Cadastre pelo menos um produto antes de vender.");
        return;
    }

    if (funcionarioService.Funcionarios.Count == 0)
    {
        Console.WriteLine("Cadastre pelo menos um funcionário antes de vender.");
        return;
    }

    Console.WriteLine("\nClientes disponíveis:");
    clienteService.ListarClientes();
    int indiceCliente = ConsoleHelper.LerIntPositivo("Escolha o número do cliente: ") - 1;

    if (indiceCliente < 0 || indiceCliente >= clienteService.Clientes.Count)
    {
        Console.WriteLine("Cliente inválido.");
        return;
    }

    Cliente clienteSelecionado = clienteService.Clientes[indiceCliente];

    Console.WriteLine("\nFuncionários disponíveis:");
    funcionarioService.ListarFuncionarios();
    int indiceFuncionario = ConsoleHelper.LerIntPositivo("Escolha o número do funcionário: ") - 1;

    if (indiceFuncionario < 0 || indiceFuncionario >= funcionarioService.Funcionarios.Count)
    {
        Console.WriteLine("Funcionário inválido.");
        return;
    }

    Funcionario funcionarioSelecionado = funcionarioService.Funcionarios[indiceFuncionario];

    List<Produto> produtosSelecionados = new List<Produto>();
    string continuar = "s";

    while (continuar.ToLower() == "s")
    {
        Console.WriteLine("\nProdutos disponíveis:");
        produtoService.ListarProdutos();
        int indiceProduto = ConsoleHelper.LerIntPositivo("Escolha o número do produto: ") - 1;

        if (indiceProduto < 0 || indiceProduto >= produtoService.Produtos.Count)
        {
            Console.WriteLine("Produto inválido.");
        }
        else
        {
            produtosSelecionados.Add(produtoService.Produtos[indiceProduto]);
            Console.WriteLine("Produto adicionado à venda.");
        }

        continuar = ConsoleHelper.LerTextoObrigatorio("Deseja adicionar mais produtos? (s/n): ");
    }

    if (produtosSelecionados.Count == 0)
    {
        Console.WriteLine("Nenhum produto foi selecionado.");
        return;
    }

    string formaPagamento = ConsoleHelper.LerTextoObrigatorio("Forma de pagamento: ");
    vendaService.RealizarVenda(clienteSelecionado, funcionarioSelecionado, produtosSelecionados, formaPagamento);
}

void CancelarVendaPeloMenu()
{
    if (vendaService.Vendas.Count == 0)
    {
        Console.WriteLine("Nenhuma venda cadastrada.");
        return;
    }

    Console.WriteLine("\nVendas disponíveis:");
    vendaService.ListarVendas();

    int indice = ConsoleHelper.LerIntPositivo("Escolha o número da venda para cancelar: ") - 1;

    if (indice < 0 || indice >= vendaService.Vendas.Count)
    {
        Console.WriteLine("Venda inválida.");
        return;
    }

    string confirmacao = ConsoleHelper.LerTextoObrigatorio("Tem certeza que deseja cancelar? (s/n): ");

    if (confirmacao.ToLower() == "s")
    {
        vendaService.CancelarVenda(indice);
    }
    else
    {
        Console.WriteLine("Cancelamento abortado.");
    }
}