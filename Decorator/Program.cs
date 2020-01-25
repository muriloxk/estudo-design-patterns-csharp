using System;
using System.Collections.Generic;
using System.Linq;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var listaContas = new List<Conta>()
            {
                new Conta(90, DateTime.Now.AddYears(-1)),
                new Conta(150, DateTime.Now.AddYears(-1)),
                new Conta(150, DateTime.Now.AddYears(-1)),
                new Conta(500_100, DateTime.Now.AddYears(-1)),
                new Conta(500_100, DateTime.Now),
            };

            var filtros = new FiltroContaSaldoMaiorQueQuinhetosMil(new FiltroContaSaldoMenorQueCem(new FiltroContasComAberturaNoMesCorrente()));
            var contasFiltradas = filtros.Filtra(listaContas);

            ImprimirContasFiltradas(contasFiltradas);
            Console.ReadKey();
        }

        private static void ImprimirContasFiltradas(IList<Conta> contasFiltradas)
        {
            var contador = 0;
            foreach (var conta in contasFiltradas)
            {
                Console.WriteLine($"{contador}. {conta}");
                contador += 1;
            }
        }
    }

    public class Conta
    {
        public Conta(double saldo,
                     DateTime dataAbertura)
        {
            Saldo = saldo;
            DataAbertura = dataAbertura;
        }

        public double Saldo { get; set; }
        public DateTime DataAbertura { get; set; }

        public override string ToString()
        {
            return $"[ {Saldo}, {DataAbertura.ToString("dd/MM/yyyy")} ]";
        }
    }

    public abstract class Filtro
    {
        protected Filtro Proximo { get; set; }
        protected IList<Conta> ContasFiltradas { get; set; }

        protected Filtro(Filtro proximo)
        {
            Proximo = proximo;
            ContasFiltradas = new List<Conta>();
        }

        protected Filtro()
        {
            Proximo = null;
            ContasFiltradas = new List<Conta>();
        }

        public IList<Conta> Filtra(IList<Conta> contas)
        {
            foreach (var conta in contas)
            {
                if (CondicaoFiltro(conta))
                    ContasFiltradas.Add(conta);
            }

            return ContasFiltradas.Concat(ProximoFiltro(contas).Where(p => !ContasFiltradas.Contains(p))).ToList();
        }

        protected abstract bool CondicaoFiltro(Conta conta);

        protected IList<Conta> ProximoFiltro(IList<Conta> contas)
        {
            if (Proximo == null)
                return new List<Conta>();

            return Proximo.Filtra(contas);
        }
    }

    public class FiltroContaSaldoMenorQueCem : Filtro
    {
        public FiltroContaSaldoMenorQueCem(Filtro proximo ) : base(proximo) { }
        public FiltroContaSaldoMenorQueCem() : base() { }

        protected override bool CondicaoFiltro(Conta conta)
        {
            return conta.Saldo < 100;
        }
    }

    public class FiltroContaSaldoMaiorQueQuinhetosMil : Filtro
    {
        public FiltroContaSaldoMaiorQueQuinhetosMil(Filtro proximo) : base(proximo) { }
        public FiltroContaSaldoMaiorQueQuinhetosMil() : base() { }

        protected override bool CondicaoFiltro(Conta conta)
        {
            return conta.Saldo > 500_000;
        }
    }

    public class FiltroContasComAberturaNoMesCorrente : Filtro
    {
        public FiltroContasComAberturaNoMesCorrente(Filtro proximo) : base(proximo) { }
        public FiltroContasComAberturaNoMesCorrente() : base() { }

        protected override bool CondicaoFiltro(Conta conta)
        {
            return conta.DataAbertura.Month == DateTime.Now.Month
                   && conta.DataAbertura.Year == DateTime.Now.Year;
        }
    }
}
