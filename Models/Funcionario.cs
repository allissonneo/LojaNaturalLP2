namespace LojaNatural.Models;

public class Funcionario
{
    public string Nome { get; set; }
    public string Cargo { get; set; }
    public double Salario { get; set; }
    public string Regime { get; set; } // CLT ou CNPJ
    public TimeSpan HoraEntrada { get; set; }
    public TimeSpan HoraSaida { get; set; }

    public Funcionario(string nome, string cargo, double salario)
    {
        Nome = nome;
        Cargo = cargo;
        Salario = salario;
    }
}