namespace LojaNatural.Models
{
    public class Produto
    {
        public string Nome { get; set; }
        public double Preco { get; set; }
        public string Categoria { get; set; }
        public string Unidade { get; set; }

        public Produto(string nome, double preco, string categoria, string unidade)
        {
            Nome = nome;
            Preco = preco;
            Categoria = categoria;
            Unidade = unidade;
        }

        public override string ToString()
        {
            return $"{Nome} - R$ {Preco:F2} ({Categoria})";
        }
    }
}