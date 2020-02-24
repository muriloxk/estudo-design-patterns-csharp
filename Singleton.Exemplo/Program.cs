using System;
using System.Collections.Generic;

namespace Singleton.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var instancia1 = LoadBalancer.GetLoadBalancer();
            var instancia2 = LoadBalancer.GetLoadBalancer();
            var instancia3 = LoadBalancer.GetLoadBalancer();

            Console.WriteLine(Object.ReferenceEquals(instancia1, instancia2));
            Console.WriteLine(Object.ReferenceEquals(instancia2, instancia3));

            Console.ReadKey();
        }
    }

    public class Server
    {
        public string Name { get; set; }
        public string IP { get; set; }
    }

    public sealed class LoadBalancer
    {
        private static readonly LoadBalancer Instance = new LoadBalancer();
        private List<Server> _servers;

        private LoadBalancer()
        {
            _servers = new List<Server>()
            {
                new Server { Name = "ServerI", IP = "120.14.220.18" },
                new Server { Name = "ServerII", IP = "120.14.220.19" },
                new Server { Name = "ServerIII", IP = "120.14.220.20" },
                new Server { Name = "ServerIV", IP = "120.14.220.21" },
                new Server { Name = "ServerII", IP = "120.14.220.22" },
            };
        }

        public static LoadBalancer GetLoadBalancer()
        {
            return Instance;
        }
    }
}
