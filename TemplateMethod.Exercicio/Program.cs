using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TemplateMethod.Exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            var bancoItau = new Banco("Itau", "Av. Paulista, São Paulo - SP", "(55) 88888-8888", "sac@itau.com.br");
            bancoItau.AdicionarConta(new Conta("Murilo", "131", "1312-1", 10000000));
            bancoItau.AdicionarConta(new Conta("José", "131", "1312-1", 10000));
            bancoItau.AdicionarConta(new Conta("Maria", "131", "1312-1", 5000000000000));

            var relatorioSimples = new RelatorioSimples();
            var relatorioComplexo = new RelatorioComplexo();

            Console.WriteLine("Relatorio simples: ");
            relatorioSimples.GerarRelatorio(bancoItau);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Relatorio Complexo: ");
            relatorioComplexo.GerarRelatorio(bancoItau);

            Console.ReadKey();
        }
    }

    public class Banco
    {
        public Banco(string nome, string endereco, string telefone, string email)
        {
            Nome = nome;
            Endereco = endereco;
            Telefone = telefone;
            Email = email;
            _contas = new List<Conta>();
        }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        private List<Conta> _contas;
        public ReadOnlyCollection<Conta> Contas
        {
            get
            {
                return new ReadOnlyCollection<Conta>(_contas);
            }

            private set { }
        }

        public void AdicionarConta(Conta conta)
        {
            _contas.Add(conta);
        }
    }

    public class Conta
    {
        public Conta(string titular, string agencia, string numeroConta, double saldo)
        {
            Titular = titular;
            Agencia = agencia;
            NumeroConta = numeroConta;
            Saldo = saldo;
        }

        public string Titular { get; set; }
        public string Agencia { get; set; }
        public string NumeroConta { get; set; }
        public double Saldo { get; set; }
    }

    public interface IRelatorio
    {
        void GerarRelatorio(Banco banco);
    }

    public abstract class Relatorio : IRelatorio
    {
        public void GerarRelatorio(Banco banco)
        {
            ImprimirCabecalho(banco);
            Console.WriteLine("********************");
            ImprimirContas(banco);
            Console.WriteLine("********************");
            ImprimirRodape(banco);
        }

        protected abstract void ImprimirCabecalho(Banco banco);
        protected abstract void ImprimirContas(Banco banco);
        protected abstract void ImprimirRodape(Banco banco);
    }

    public class RelatorioComplexo : Relatorio
    {
        protected override void ImprimirCabecalho(Banco banco)
        {
            Console.WriteLine(banco.Nome);
            Console.WriteLine($"Endereço: {banco.Endereco}");
            Console.WriteLine($"Telefone: {banco.Telefone}");
        }

        protected override void ImprimirContas(Banco banco)
        {
            foreach(Conta conta in banco.Contas)
            {
                Console.WriteLine();
                Console.WriteLine("[ ");
                Console.WriteLine($" Titular: {conta.Titular};");
                Console.WriteLine($" Agência: {conta.Agencia};");
                Console.WriteLine($" Numero da conta: {conta.NumeroConta};");
                Console.WriteLine($" Saldo: {conta.Saldo.ToString("C")};");
                Console.Write("]");
                Console.WriteLine();
            }
        }

        protected override void ImprimirRodape(Banco banco)
        {
            Console.WriteLine(banco.Email);
            Console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
        }
    }

    public class RelatorioSimples : Relatorio
    {
        protected override void ImprimirCabecalho(Banco banco)
        {
            Console.WriteLine($"{banco.Nome} - {banco.Telefone}");
        }

        protected override void ImprimirContas(Banco banco)
        {
            foreach (Conta conta in banco.Contas)
            {
                Console.WriteLine($"[Titular: {conta.Titular}, Saldo: {conta.Saldo.ToString("C")}]");
            }
        }

        protected override void ImprimirRodape(Banco banco)
        {
            ImprimirCabecalho(banco);
        }
    }
}
