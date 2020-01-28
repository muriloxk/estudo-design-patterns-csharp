using System;
using System.Collections.Generic;

namespace Memento.Exemplo2
{
    class Program
    {
        static void Main(string[] args)
        {
            var contrato = new Contrato(DateTime.Now, "Cliente 1", TipoContrato.Novo);
            contrato.ExibirFaseContrato();
            contrato.Avanca();
            contrato.ExibirFaseContrato();
            contrato.Avanca();
            contrato.ExibirFaseContrato();
            contrato.Avanca();
            contrato.ExibirFaseContrato();
            contrato.Voltar();
            contrato.ExibirFaseContrato();
            contrato.Voltar();
            contrato.ExibirFaseContrato();

            Console.ReadKey();
        }
    }

    public enum TipoContrato
    {
        Novo,
        EmAndamento,
        Acertado,
        Concluido,
    }

    public class Contrato
    {
        public DateTime Data { get; private set; }
        public string Cliente { get; private set; }
        public TipoContrato Tipo { get; private set; }
        private HistoricoContrato Historico { get; set; }

        public Contrato(DateTime data, string cliente, TipoContrato tipo)
        {
            Data = data;
            Cliente = cliente;
            Tipo = tipo;
            Historico = new HistoricoContrato();
        }

        public void Avanca()
        {
            if (Tipo == TipoContrato.Novo)
            {
                Historico.AdicionarUmEstadoDoContrato(new ContratoMemento(new Contrato(this.Data, this.Cliente, this.Tipo)));
                Tipo = TipoContrato.EmAndamento;   
            }
            else if (Tipo == TipoContrato.EmAndamento)
            {
                Historico.AdicionarUmEstadoDoContrato(new ContratoMemento(new Contrato(this.Data, this.Cliente, this.Tipo)));
                Tipo = TipoContrato.Acertado;
            }
            else if (Tipo == TipoContrato.Acertado)
            {
                Historico.AdicionarUmEstadoDoContrato(new ContratoMemento(new Contrato(this.Data, this.Cliente, this.Tipo)));
                Tipo = TipoContrato.Concluido;
            }
        }

        public void Voltar()
        {
            Tipo = Historico.RetornarUltimoEstadoDoContrato().Contrato.Tipo;
        }

        public void ExibirFaseContrato()
        {
            Console.WriteLine(Tipo);
        }
    }

    public class ContratoMemento
    {
        public Contrato Contrato { get; private set; }

        public ContratoMemento(Contrato contratoMemento)
        {
            Contrato = contratoMemento;
        }
    }

    public class HistoricoContrato
    {
        private List<ContratoMemento> ContratosMemento { get; set; }

        public HistoricoContrato()
        {
            ContratosMemento = new List<ContratoMemento>();
        }


        public void AdicionarUmEstadoDoContrato(ContratoMemento contrato)
        {
            ContratosMemento.Add(contrato);
        }

        public ContratoMemento RetornarUltimoEstadoDoContrato()
        {
            if (ContratosMemento.Count <= 0)
                return null;

            var estadoContrato = ContratosMemento[ContratosMemento.Count - 1];
            ContratosMemento.Remove(estadoContrato);
            return estadoContrato;
        }
    }


}
