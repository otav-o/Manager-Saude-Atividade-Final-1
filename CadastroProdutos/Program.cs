using System;

namespace CadastroProdutos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao gerenciador de produtos".ToUpper());

            direcionaResposta();

            Console.WriteLine("O programa foi finalizado em " + DateTime.Now);

            Console.ReadLine();
        }

        /// <summary>
        /// Procedimento recursivo que chama métodos com base na resposta do usuário.
        /// </summary>
        private static void direcionaResposta()
        {
            char resp = executaMenu();

            if (resp == 'a') VetorProdutos.CadastrarProduto();
            else if (resp == 'b') VetorProdutos.AtualizarPreco();
            else if (resp == 'c') VetorProdutos.ImprimirPrecoMedio();
            else if (resp == 'd') VetorProdutos.MostrarProdutos();
            else if (resp == 'x') return; // finaliza o procedimento

            direcionaResposta();

        }

        /// <summary>
        /// Menu principal que exibe opções ao usuário e devolve sua resposta.
        /// </summary>
        private static char executaMenu()
        {
            Console.Write("--------------------------" +
                "\n[a] Cadastrar produto" +
                "\n[b] Atualizar preço" +
                "\n[c] Imprimir preço médio" +
                "\n[d] Mostrar todos os produtos" +
                "\n[x] Encerrar programa" +
                "\nDigite a letra da opção desejada: ");

            char resp = Convert.ToChar(Console.ReadLine().ToLower().Trim());
            Console.WriteLine("--------------------------");
            return resp;
        }

    }
}
/* TODO verificar como as exceções entrariam nesse programa e como seriam lançadas na cadeia de métodos (onde eu as colocaria? no primeiro ou último método?)
 * TODO criar uma biblioteca somente com as classes separada da interface do usuário (VetorProdutos está adequado? Leitura de dados somente na classe Program?) 
 * TODO perguntar para o Camillo como ele resolveria esse desafio*/