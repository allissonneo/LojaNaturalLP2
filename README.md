







O sistema foi modelado utilizando Programação Orientada a Objetos.  
As entidades principais são Cliente, Produto, Venda, Funcionário e Loja.  
As relações mostram que um cliente pode realizar múltiplas vendas e cada venda contém uma coleção de produtos utilizando List<T>.


## Diagrama de Classes

```mermaid
classDiagram

class Cliente {
  string Nome
  string Email
  string Login
  string Senha
  List<Venda> HistoricoCompras
}

class Produto {
  string Nome
  double Preco
  string Categoria
  string TipoVenda
  List<string> Tags
}

class Venda {
  Cliente Cliente
  List<Produto> Produtos
  double ValorTotal
  string FormaPagamento
  CalcularTotal()
}

class Funcionario {
  string Nome
  string Cargo
  double Salario
  string Regime
  Time HoraEntrada
  Time HoraSaida
}

class Loja {
  string Nome
  string Endereco
  List<Produto> Produtos
  List<Funcionario> Funcionarios
}

Cliente "1" --> "*" Venda : realiza
Venda "*" --> "*" Produto : contém
Loja "1" --> "*" Produto : possui
Loja "1" --> "*" Funcionario : possui
