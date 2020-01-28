using System;
using System.Collections.Generic;

namespace Memento.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            Texto texto = new Texto();
            texto.EscreverTexto("Primeira linha do texto\n");
            texto.EscreverTexto("Segunda linha do texto\n");
            texto.EscreverTexto("Terceira linha do texto\n");
            Console.WriteLine(texto);
            texto.DesfazerEscrita();
            Console.WriteLine(texto);
            texto.DesfazerEscrita();
            Console.WriteLine(texto);
            texto.DesfazerEscrita();
            Console.WriteLine(texto);
            texto.DesfazerEscrita();
            Console.WriteLine(texto);

            Console.ReadKey();
        }
    }

    public class TextoMemento
    {
        public string EstadoTexto { get; protected set; }

        public TextoMemento(string texto)
        {
            EstadoTexto = texto;
        }
    }

    public class HistoricoTexto
    {
        protected List<TextoMemento> Estados { get; set; }

        public HistoricoTexto()
        {
            Estados = new List<TextoMemento>();
        }

        public void Adicionar(TextoMemento textoMemento)
        {
            Estados.Add(textoMemento);
        }

        public TextoMemento GetUltimoEstadoSalvo()
        {
            if (Estados.Count <= 0)
                return new TextoMemento("");

            TextoMemento estadoSalvo = Estados[Estados.Count - 1];
            Estados.Remove(estadoSalvo);

            return estadoSalvo;
        }
    }

    public class Texto
    {
        protected string TextoAtual { get; set; }
        private HistoricoTexto Historico { get; set; }

        public Texto()
        {
            Historico = new HistoricoTexto();
            TextoAtual = "";
        }

        public void EscreverTexto(string novoTexto)
        {
            Historico.Adicionar(new TextoMemento(TextoAtual));
            TextoAtual += novoTexto;
        }

        public void DesfazerEscrita()
        {
            TextoAtual = Historico.GetUltimoEstadoSalvo().EstadoTexto;
        }

        public override string ToString()
        {
            return TextoAtual;
        }
    }

}
