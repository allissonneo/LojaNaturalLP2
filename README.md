







O sistema foi modelado utilizando Programação Orientada a Objetos.  
As entidades principais são Cliente, Produto, Venda, Funcionário e Loja.  
As relações mostram que um cliente pode realizar múltiplas vendas e cada venda contém uma coleção de produtos utilizando List<T>.
Produto representa os itens vendidos pela loja.

Cliente representa quem compra.

Funcionário representa quem registra a venda.

Venda representa a transação.

ItemVenda liga um produto a uma quantidade dentro da venda.


## Diagrama de Classes

```mermaid
classDiagram
    class Produto {
        +int Id
        +string Nome
        +double Preco
        +string Categoria
    }

    class Cliente {
        +string Nome
        +string Email
        +List~Venda~ HistoricoCompras
    }

    class Funcionario {
        +string Nome
        +string Cargo
        +double Salario
    }

    class ItemVenda {
        +Produto Produto
        +int Quantidade
        +double Total()
    }

    class Venda {
        +Cliente Cliente
        +Funcionario Funcionario
        +List~ItemVenda~ Itens
        +DateTime Data
        +double CalcularTotal()
    }

    Cliente "1" --> "*" Venda : realiza
    Funcionario "1" --> "*" Venda : registra
    Venda "1" --> "*" ItemVenda : contem
    ItemVenda "*" --> "1" Produto : refere-se a
