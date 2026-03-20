namespace LojaNatural.Models
{
    public class Venda
    {
        public Cliente Cliente { get; set; }
        public Funcionario Funcionario { get; set; }
        public List<Produto> Produtos { get; set; }
        public string FormaPagamento { get; set; }
        public DateTime Data { get; set; }

        public Venda()
        {
            Cliente = new Cliente();
            Funcionario = new Funcionario();
            Produtos = new List<Produto>();
            FormaPagamento = string.Empty;
            Data = DateTime.Now;
        }

        public Venda(Cliente cliente, Funcionario funcionario, List<Produto> produtos, string formaPagamento)
        {
            Cliente = cliente;
            Funcionario = funcionario;
            Produtos = produtos;
            FormaPagamento = formaPagamento;
            Data = DateTime.Now;
        }

        public double CalcularTotal()
        {
            return Produtos.Sum(p => p.Preco);
        }

        public override string ToString()
        {
            return $"Data: {Data:dd/MM/yyyy} | Cliente: {Cliente.Nome} | Funcionário: {Funcionario.Nome} | Total: R$ {CalcularTotal():F2}";
        }
    }
}