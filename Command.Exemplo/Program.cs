using System;
using System.Collections.Generic;

namespace Command.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var filaDeProcessos = new FilaDeTrabalho();

            var pedido1 = new Pedido("Murilo", 500);
            filaDeProcessos.Adicionar(new PagarPedido(pedido1));
            filaDeProcessos.Adicionar(new FinalizaPedido(pedido1));

            var pedido2 = new Pedido("José", 500);
            filaDeProcessos.Adicionar(new PagarPedido(pedido2));
            filaDeProcessos.Adicionar(new FinalizaPedido(pedido2));

            filaDeProcessos.ExecutarComandos();
            Console.ReadKey();
        }
    }

    public interface ICommand
    { 
        void Executa();
    }

    public class FilaDeTrabalho
    {
        private IList<ICommand> ListaDeComandos { get; set; }

        public FilaDeTrabalho()
        {
            ListaDeComandos = new List<ICommand>();
        }

        public void Adicionar(ICommand command)
        {
            ListaDeComandos.Add(command);
        }

        public void ExecutarComandos()
        {
            foreach (ICommand command in ListaDeComandos)
                command.Executa();
        }
    }

    public class PagarPedido : ICommand
    {
        public Pedido Pedido { get; private set; }

        public PagarPedido(Pedido pedido)
        {
            Pedido = pedido;
        }

        public void Executa()
        {
            Pedido.Paga();
          
        }
    }

    public class FinalizaPedido : ICommand
    {
        public Pedido Pedido { get; private set; }

        public FinalizaPedido(Pedido pedido)
        {
            Pedido = pedido;
        }

        public void Executa()
        {
            Pedido.Finaliza();
        }
    }

    public class Pedido
    {
        public String Cliente { get; private set; }
        public double Valor { get; private set; }
        public Status Status { get; private set; }
        public DateTime DataFinalizacao { get; private set; }

        public Pedido(String cliente, double valor)
        {
            Cliente = cliente;
            Valor = valor;
            Status = Status.Novo;
        }

        public void Paga()
        {
            Status = Status.Pago;
            Console.WriteLine($"Pagando pedido do {Cliente}");
        }

        public void Finaliza()
        {
            DataFinalizacao = DateTime.Now;
            Status = Status.Entregue;

            Console.WriteLine($"Finalizando pedido do {Cliente}");
        }
    }

    public enum Status
    {
        Novo,
        Processado,
        Pago,
        ItemSeparado,
        Entregue
    }
}
