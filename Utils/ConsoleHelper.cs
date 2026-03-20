namespace LojaNatural.Utils
{
    public static class ConsoleHelper
    {
        public static string LerTextoObrigatorio(string mensagem)
        {
            string valor;
            do
            {
                Console.Write(mensagem);
                valor = Console.ReadLine()!.Trim();

                if (string.IsNullOrWhiteSpace(valor))
                    Console.WriteLine("Campo obrigatório. Tente novamente.");

            } while (string.IsNullOrWhiteSpace(valor));

            return valor;
        }

        public static int LerIntPositivo(string mensagem)
        {
            int valor;
            do
            {
                Console.Write(mensagem);
                if (int.TryParse(Console.ReadLine(), out valor) && valor > 0)
                    return valor;

                Console.WriteLine("Valor inválido. Digite um inteiro maior que zero.");
            } while (true);
        }

        public static double LerDoublePositivo(string mensagem)
        {
            double valor;
            do
            {
                Console.Write(mensagem);
                if (double.TryParse(Console.ReadLine(), out valor) && valor > 0)
                    return valor;

                Console.WriteLine("Valor inválido. Digite um número maior que zero.");
            } while (true);
        }

        public static string LerEmailValido(string mensagem)
        {
            string email;
            do
            {
                Console.Write(mensagem);
                email = Console.ReadLine()!.Trim();

                if (!string.IsNullOrWhiteSpace(email) &&
                    email.Contains("@") &&
                    email.Contains(".") &&
                    email.IndexOf("@") < email.LastIndexOf("."))
                {
                    return email;
                }

                Console.WriteLine("Email inválido. Digite um email no formato exemplo@dominio.com");
            } while (true);
        }
    }
}