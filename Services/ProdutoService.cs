using LojaNatural.Models;
using LojaNatural.Utils;

namespace LojaNatural.Services
{
    public class ProdutoService
    {

        public List<Produto> Produtos { get; set; }

        public ProdutoService()
        {
            Produtos = DataStore.CarregarProdutos();

            if (Produtos.Count == 0)
            {
                Produtos.Add(new Produto("Amendoim", 15.0, "Natural", "Unidade"));
                Produtos.Add(new Produto("Castanha", 20.0, "Natural", "Unidade"));
                DataStore.SalvarProdutos(Produtos);
            }
            Produtos = DataStore.CarregarProdutos();
        }

        public void CadastrarProduto(string nome, double preco, string categoria, string unidade)
        {
            Produto produto = new Produto(nome, preco, categoria, unidade);
            Produtos.Add(produto);
            DataStore.SalvarProdutos(Produtos);
            Console.WriteLine("Produto cadastrado!");
        }

        public void ListarProdutos()
        {
            if (Produtos.Count == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado.");
                return;
            }

            for (int i = 0; i < Produtos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Produtos[i]}");
            }
        }
        public void ExcluirProduto(int indice)
        {
            if (indice < 0 || indice >= Produtos.Count)
            {
                Console.WriteLine("Produto inválido.");
                return;
            }

            Produtos.RemoveAt(indice);
            DataStore.SalvarProdutos(Produtos);

            Console.WriteLine("Produto excluído com sucesso!");
        }
    }

}