using System;
namespace StatePattern.Exercicio.Domain
{
    public class Conta
    {
        public Conta(string titular, double saldo)
        {
            Titular = titular;
            Saldo = saldo;
            Estado = new Positiva();
        }

        public string Titular { get; internal set; }
        public double Saldo { get; internal set; }
        internal IEstadoConta Estado { get; set; }

        public void Depositar(double quantia)
        {
            Estado.Depositar(this, quantia);
        }

        public void Sacar(double quantia)
        {
            Estado.Sacar(this, quantia);

            if (Saldo < 0 && Estado.GetType() != typeof(Negativa))
                Estado = new Negativa(Titular);
        }
    }

    internal interface IEstadoConta
    {
        void Depositar(Conta conta, double quantia);
        void Sacar(Conta conta, double quantia);
    }

    internal class Negativa : IEstadoConta
    {
        public Negativa(string titular)
        {
            Console.WriteLine($"A conta do {titular} foi negativada");
        }

        public void Sacar(Conta conta, double quantia)
        {
            throw new Exception("Você não pode realizar saque, a conta esta negativa");
        }

        public void Depositar(Conta conta, double quantia)
        {
            var valor = quantia * 0.95;
            conta.Saldo += valor;
            Console.WriteLine($"Saldo após o depósito da quantia de {valor}: {conta.Saldo}");
        }
    }

    internal class Positiva : IEstadoConta
    {
        public void Sacar(Conta conta, double quantia)
        {
            conta.Saldo -= quantia;
            Console.WriteLine($"Saldo após o saque : {conta.Saldo}");
        }

        public void Depositar(Conta conta, double quantia)
        {
            var valor = quantia * 0.98;
            conta.Saldo += valor;
            Console.WriteLine($"Saldo após o depósito da quantia de {valor}: {conta.Saldo}");
        }
    }
}
