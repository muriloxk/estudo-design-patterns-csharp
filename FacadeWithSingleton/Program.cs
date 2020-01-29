using System;

namespace FacadeWithSingleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var empresaFacade = EmpresaSingleton.Instancia;
            var cliente = new Cliente("Murilo");

            empresaFacade.SalvarCliente(cliente);
            empresaFacade.LancarFatura(cliente, new Cobranca());
            empresaFacade.Cobrar(cliente);

            Console.ReadKey();
        }
    }

    public class Cliente
    {
        public Cliente(string nome)
        {
            Nome = nome;
        }

        public override string ToString()
        {
            return Nome;
        }

        public string Nome { get; private set; }
    }

    public class ClienteDAO
    {
        public void Salvar(Cliente cliente)
        {
            Console.WriteLine("Salvou o cliente {0}", cliente);
        }
    }

    public class Cobranca
    {
        public void Cobrar(Cliente cliente)
        {
            Console.WriteLine("Cobrou o cliente");
        }
    }

    public class Fatura
    {
        public void LancarFatura(Cliente cliente, Cobranca cobranca)
        {
            Console.WriteLine("Lançou a fatura braba no {0}", cliente);
        }
    }

    public class EmpresaFacade
    {
        public void LancarFatura(Cliente cliente, Cobranca cobranca)
        {
            new Fatura().LancarFatura(cliente, cobranca);
        }

        public void Cobrar(Cliente cliente)
        {
            new Cobranca().Cobrar(cliente);
        }

        public void SalvarCliente(Cliente cliente)
        {
            new ClienteDAO().Salvar(cliente);
        }
    }


    public class EmpresaSingleton
    {
        private static EmpresaFacade _instancia;
        public static EmpresaFacade Instancia {

            get
            {
                if (_instancia == null)
                    _instancia = new EmpresaFacade();

                return _instancia;
            }

            private set { }

        }

        private EmpresaSingleton(){ }
    }
}
