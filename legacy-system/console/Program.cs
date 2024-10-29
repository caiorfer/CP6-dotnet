using System;
using System.Collections.Generic;
using System.IO;

class MainSistema
{
    static void Main(string[] args)
    {
        var sistemaCliente = new SistemaCliente();
        sistemaCliente.AdicionarCliente(1, "João", "joao@email.com");
        sistemaCliente.AdicionarCliente(2, "Maria", "maria@email.com");

        var sistemaTransacao = new SistemaTransacao();
        sistemaTransacao.AdicionarTransacao(1, 100.50m, "Compra de Produto");
        sistemaTransacao.AdicionarTransacao(2, 200.00m, "Compra de Serviço");
        sistemaTransacao.AdicionarTransacao(3, 300.75m, "Compra de Software");

        sistemaCliente.ExibirTodosClientes();
        sistemaTransacao.ExibirTransacoes();

        sistemaCliente.RemoverCliente(1);
        sistemaCliente.ExibirTodosClientes();

        sistemaCliente.AtualizarNomeCliente(2, "Maria Silva");

        ExibirMensagemEmpresa("Empresa Teste", "Compra de Insumo", 5);

        var relatorio = new Relatorio();
        relatorio.GerarRelatorioClientes(sistemaCliente.ObterClientes());

        int soma = CalcularSoma(10);
        Console.WriteLine($"Soma total: {soma}");
    }

    // Método para exibir mensagens de forma repetitiva
    static void ExibirMensagemEmpresa(string nomeEmpresa, string descricao, int repeticoes)
    {
        for (int i = 0; i < repeticoes; i++)
        {
            Console.WriteLine($"Nome da Empresa: {nomeEmpresa} | Descrição: {descricao}");
        }
    }

    // Método genérico para calcular a soma
    static int CalcularSoma(int limite)
    {
        int soma = 0;
        for (int i = 0; i < limite; i++)
        {
            soma += i;
        }
        return soma;
    }
}
}