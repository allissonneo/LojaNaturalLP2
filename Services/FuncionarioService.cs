using LojaNatural.Models;
using LojaNatural.Utils;

namespace LojaNatural.Services
{
    public class FuncionarioService
    {
        public FuncionarioService()
        {
            Funcionarios = DataStore.CarregarFuncionarios();

            if (Funcionarios.Count == 0)
            {
                Funcionario gerente = new Funcionario("Gerente Base", "gerente@loja.com");
                gerente.Atribuicoes.Add(Atribuicao.Gerente);
                gerente.Atribuicoes.Add(Atribuicao.Caixa);

                Funcionarios.Add(gerente);
                DataStore.SalvarFuncionarios(Funcionarios);
            }
        }
        public List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();

        public void CadastrarFuncionario(string nome, string email, List<Atribuicao> atribuicoes)
        {
            Funcionario funcionario = new Funcionario(nome, email);
            funcionario.Atribuicoes.AddRange(atribuicoes);
            Funcionarios.Add(funcionario);

            Console.WriteLine("Funcionário cadastrado!");
        }

        public void ListarFuncionarios()
        {
            if (Funcionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
                return;
            }

            for (int i = 0; i < Funcionarios.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Funcionarios[i]}");
            }
        }
        public void ExcluirFuncionario(int indice)
        {
            if (indice < 0 || indice >= Funcionarios.Count)
            {
                Console.WriteLine("Funcionário inválido.");
                return;
            }

            Funcionarios.RemoveAt(indice);
            DataStore.SalvarFuncionarios(Funcionarios);

            Console.WriteLine("Funcionário excluído com sucesso!");
        }
    }

}
