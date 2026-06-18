using System;

public class Produto
{
    public int Codigo;
    public string Descricao = "";
    public decimal PrecoCompra;
    public decimal PrecoVenda;
    public int Estoque;
}

class Program
{
    const int MAX_PRODUTOS = 500;

    static Produto[] produtos = new Produto[MAX_PRODUTOS];
    static int quantidadeProdutos = 0;
    static int proximoCodigo = 1;

    static void Main()
    {
        int opcao;

        do
        {
            Console.WriteLine("=================================");
            Console.WriteLine("        LOJA DE BRINQUEDOS         ");
            Console.WriteLine("=================================");
            Console.WriteLine("1. Cadastrar Produto");
            Console.WriteLine("2. Frente de Caixa");
            Console.WriteLine("3. Consultar Estoque");
            Console.WriteLine("4. Entrada de Produtos");
            Console.WriteLine("5. Listagem de Produtos");
            Console.WriteLine("6. Sair");
            Console.WriteLine("=================================");
            Console.Write("Escolha uma opção: ");
            opcao = int.Parse(Console.ReadLine()!);

            switch (opcao)
            {
                case 1:
                    cadastrarProduto();
                    break;
                case 2:
                    frenteDeCaixa();
                    break;
                case 3:
                    consultarEstoque();
                    break;
                case 4:
                    entradaProdutos();
                    break;
                case 5:
                    listarProdutos();
                    break;
                case 6:
                    Console.WriteLine("Encerrando o programa...");
                    break;
                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção entre 1 e 6.");
                    break;
            }
            Console.WriteLine();
        } while (opcao != 6);
    }
    static int BuscarProduto(int codigoBuscado)
    {
        for (int i = 0; i < quantidadeProdutos; i++)
        {
            if (produtos[i].Codigo == codigoBuscado)
            {
                return i;
            }
        }
        return -1;
    }

    static void cadastrarProduto()
    {
        if (quantidadeProdutos >= MAX_PRODUTOS)
        {
            Console.WriteLine("Limite máximo de produtos atingido. Não é possível cadastrar mais produtos.");
            return;
        }

        Produto produto = new Produto();
        produto.Codigo = proximoCodigo;
        proximoCodigo++;

        Console.Write("Digite a descrição do produto: ");
        produto.Descricao = Console.ReadLine()!;

        Console.Write("Digite o preço de compra do produto: ");
        produto.PrecoCompra = decimal.Parse(Console.ReadLine()!);

        Console.Write("Digite o preço de venda do produto: ");
        produto.PrecoVenda = decimal.Parse(Console.ReadLine()!);

        Console.Write("Digite a quantidade em estoque do produto: ");
        produto.Estoque = int.Parse(Console.ReadLine()!);

        produtos[quantidadeProdutos] = produto;
        quantidadeProdutos++;

        Console.WriteLine($"Produto cadastrado com sucesso! Código do produto: {produto.Codigo}");
    }
    static void frenteDeCaixa()
    {
        decimal totalCompra = 0;
        int codigo;

        do
        {
            Console.WriteLine("Digite o codigo dos produto (0 para finalizar a compra): ");
            codigo = int.Parse(Console.ReadLine()!);

            if (codigo == 0)
            {
                break;
            }

            int posicao = BuscarProduto(codigo);

            if (posicao == -1)
            {
                Console.WriteLine("Produto não encontrado. Por favor, tente novamente.");
            }

            else
            {
                if (produtos[posicao].Estoque <= 0)
                {
                    Console.WriteLine("Produto sem estoque disponível.");
                }
                else
                {
                    totalCompra += produtos[posicao].PrecoVenda;
                    produtos[posicao].Estoque--;
                    Console.WriteLine($"Produto {produtos[posicao].Descricao} adicionado ao carrinho. Preço: {produtos[posicao].PrecoVenda:C}");
                }
            }
        } while (true);
        Console.WriteLine($"Total da compra: {totalCompra:C}");
    }
    static void consultarEstoque()
    {
        Console.Write("Digite o código do produto: ");
        int codigo = int.Parse(Console.ReadLine()!);

        int posição = BuscarProduto(codigo);

        if (posição == -1)
        {
            Console.WriteLine("Produto não encontrado. Por favor, tente novamente.");
        }


        Console.WriteLine($"Código: {produtos[posição].Codigo}");
        Console.WriteLine($"Descrição: {produtos[posição].Descricao}");
        Console.WriteLine($"Preço de compra: {produtos[posição].PrecoCompra}");
        Console.WriteLine($"Preço de venda: {produtos[posição].PrecoVenda}");
        Console.WriteLine($"Quantidade em estoque: {produtos[posição].Estoque}");
    }

    static void entradaProdutos()
    {
        Console.Write("Digite o código do produto: ");
        int codigo = int.Parse(Console.ReadLine()!);

        int posição = BuscarProduto(codigo);

        if (posição == -1)
        {
            Console.WriteLine("Produto não encontrado. Por favor, tente novamente.");
        }

        Console.Write("Digite a quantidade de itens recebidos: ");
        int quantidadeRecebida = int.Parse(Console.ReadLine()!);

        Console.Write("Digite o novo preço de compra do produto: ");
        decimal novoPrecoCompra = decimal.Parse(Console.ReadLine()!);

        Console.Write("Digite o novo preço de venda do produto: ");
        decimal novoPrecoVenda = decimal.Parse(Console.ReadLine()!);

        produtos[posição].Estoque += quantidadeRecebida;
        produtos[posição].PrecoCompra = novoPrecoCompra;
        produtos[posição].PrecoVenda = novoPrecoVenda;

        Console.WriteLine("Produto atualizado com sucesso!");
    }

    static void listarProdutos()
    {
        if (quantidadeProdutos == 0)
        {
            Console.WriteLine("Nenhum produto cadastrado.");
            return;
        }

        Console.WriteLine("Lista de Produtos Cadastrados:");
        for (int i = 0; i < quantidadeProdutos; i++)
        {
            Console.WriteLine("---------------------------------");
            Console.WriteLine($"Código: {produtos[i].Codigo}");
            Console.WriteLine($"Descrição: {produtos[i].Descricao}");
            Console.WriteLine($"Preço de compra: {produtos[i].PrecoCompra}");
            Console.WriteLine($"Preço de venda: {produtos[i].PrecoVenda}");
            Console.WriteLine($"Quantidade em estoque: {produtos[i].Estoque}");
            Console.WriteLine("---------------------------------");
        }
    }
}

