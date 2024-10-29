using System;
using System.Collections.Generic;

namespace LegacySystem
{
    // Classe Cliente com boas práticas
    class Cliente
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime DataCadastro { get; private set; }

        public Cliente(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            AtualizarEmail(email);
            DataCadastro = DateTime.Now;
        }

        public void AlterarNome(string nome)
        {
            if (!string.IsNullOrWhiteSpace(nome))
                Nome = nome;
        }

        public void AtualizarEmail(string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && email.Contains("@"))
                Email = email;
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Id: {Id} | Nome: {Nome} | Email: {Email} | Cadastro: {DataCadastro}");
        }
    }

    // Classe Transacao simplificada
    class Transacao
    {
        public int Id { get; }
        public decimal Valor { get; }
        public string Descricao { get; }
        public DateTime Data { get; }

        public Transacao(int id, decimal valor, string descricao)
        {
            Id = id;
            Valor = valor;
            Descricao = descricao;
            Data = DateTime.Now;
        }

        public void Exibir()
        {
            Console.WriteLine($"Id: {Id} | Valor: {Valor} | Descrição: {Descricao} | Data: {Data}");
        }
    }

    // Sistema de Clientes refatorado
    class SistemaCliente
    {
        private List<Cliente> clientes = new();

        public void AdicionarCliente(int id, string nome, string email)
        {
            clientes.Add(new Cliente(id, nome, email));
        }

        public void RemoverCliente(int id)
        {
            var cliente = clientes.Find(c => c.Id == id);
            if (cliente != null)
                clientes.Remove(cliente);
        }

        public void AtualizarNomeCliente(int id, string nome)
        {
            var cliente = clientes.Find(c => c.Id == id);
            cliente?.AlterarNome(nome);
        }

        public void ExibirTodosClientes()
        {
            foreach (var cliente in clientes)
                cliente.ExibirDados();
        }

        public List<Cliente> ObterClientes() => new(clientes);
    }

    // Sistema de Transações refatorado
    class SistemaTransacao
    {
        private List<Transacao> transacoes = new();

        public void AdicionarTransacao(int id, decimal valor, string descricao)
        {
            transacoes.Add(new Transacao(id, valor, descricao));
        }

        public void ExibirTransacoes()
        {
            foreach (var transacao in transacoes)
                transacao.Exibir();
        }
    }

    // Classe de Relatório simplificada
    class Relatorio
    {
        public void GerarRelatorioClientes(IEnumerable<Cliente> clientes)
        {
            foreach (var cliente in clientes)
                Console.WriteLine($"Cliente: {cliente.Nome} | Email: {cliente.Email}");
        }
    }