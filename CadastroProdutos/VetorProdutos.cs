using System;
using System.Collections.Generic;
using System.Text;

namespace CadastroProdutos
{
    /// <summary>
    /// Classe que armazena um vetor de produtos.
    /// </summary>
    static class VetorProdutos
    {
        /// <summary>
        /// Tamanho fixo do vetor (máximo de produtos que podem ser cadastrados)
        /// </summary>
        private const int V = 100;

        public static Produto[] Produtos { get; private set; } = new Produto[V];

        /// <summary>
        /// Representa o número de produtos cadastrados e também o próximo índice vazio do vetor produtos.
        /// </summary>
        public static int QuantidadeCadastrada { get; private set; } = 0;

        /// <summary>
        /// Recebe do usuário informações para criar um produto e adicioná-lo ao vetor.
        /// </summary>
        public static void CadastrarProduto() // TODO acredito que deveria estar na UI, pois nada garante que a aplicação é do tipo console!
        {
            if (QuantidadeCadastrada != V)
            {
                Console.Write("Código: ");
                int codigo = Convert.ToInt32(Console.ReadLine());

                Console.Write("Descrição: ");
                string descricao = Console.ReadLine();

                Console.Write("Preço: ");
                double preco = Convert.ToDouble(Console.ReadLine());

                Console.Write("Custo: ");
                double custo = Convert.ToDouble(Console.ReadLine());

                // O produto é inserido no próximo índice nulo
                Produtos[QuantidadeCadastrada] = new Produto(codigo, descricao, preco, custo);

                // QuantidadeCadastrada pertence ao vetor de produtos
                QuantidadeCadastrada++;
            }
            else
            {
                Console.WriteLine($"Não é possível inserir mais produtos. Limite de {V} atingido");
                return;
            }
        }

        /// <summary>
        /// Imprime todos os produtos e suas propriedades
        /// </summary>
        public static void MostrarProdutos()
        {
            for (int i = 0; i < QuantidadeCadastrada; i++) // o foreach percorre posições nulas e daria um erro
            {
                Produto p = Produtos[i];
                Console.WriteLine("Cod.: {0}" +
                    "\n  Descrição: {1}" +
                    "\n  Preço: R${2:N2}" +
                    "\n  Custo: R${3:N2}" +
                    "\n  Lucro: R${4:N2}",
                    p.Codigo, p.Descricao, p.Preco, p.Custo, p.Preco - p.Custo);
            }
        }

        /// <summary>
        /// Chama a função CalculaPrecoMedio() e imprime o resultado
        /// </summary>
        public static void ImprimirPrecoMedio()
        {
            Console.WriteLine("O preço médio de {0} produtos cadastrados é R${1:N2}.", QuantidadeCadastrada, CalculaPrecoMedio());
        }

        /// <summary>
        /// Lê as informações do usuário e chama Produto.AumentaPreco() ou Produto.ReduzPreco()
        /// </summary>
        public static void AtualizarPreco()
        {
            // Ler o código do produto
            Console.Write("** Atualização de preço\nDigite o código do produto: ");
            int cod = Convert.ToInt32(Console.ReadLine());

            // Receber o produto
            Produto p = BuscarProduto(cod);

            if (p == null)
            {
                Console.WriteLine("O código inserido não pertence a nenhum produto");
                return;
            }
            
            Console.Write("Você deseja aumentar ou reduzir o preço? ");
            int respAouR = Convert.ToChar(Console.ReadLine().ToLower().Trim()[0]); // pega o primeiro caractere

            Console.Write("Em quantos por cento? ");
            double porcentagem = Convert.ToDouble(Console.ReadLine()) / 100;

            if (respAouR == 'a') p.AumentaPreco(porcentagem);
            else if (respAouR == 'r') p.ReduzPreco(porcentagem);

            Console.WriteLine("Sucesso. Novo preço: R${0:N2}", p.Preco);
        }

        /// <summary>
        /// Percorre o vetor Produtos, calcula e retorna o preço médio deles
        /// </summary>
        /// <returns></returns>
        private static double CalculaPrecoMedio()
        {
            double soma = 0;
            for (int i = 0; i < QuantidadeCadastrada; i++)
            {
                soma += Produtos[i].Preco;
            }
            return soma / QuantidadeCadastrada;
        }

        /// <summary>
        /// Retorna um produto do vetor da classe. 
        /// </summary>
        /// <param name="cod">Código cadastrado para o produto.</param>
        /// <returns></returns>
        private static Produto BuscarProduto(int cod)
        {
            for (int i = 0; i < QuantidadeCadastrada; i++)
            {
                if (Produtos[i].Codigo == cod) 
                    return Produtos[i];
            }
            return null;


        }
    }
}
