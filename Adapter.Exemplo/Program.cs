using System;

namespace Adapter.Exemplo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var tomadaDe3 = new TomadaDeTresPinos();

            var adaptador = new AdapterTomada(tomadaDe3);
            adaptador.LigarTomadaDeDoisPinos();

            TomadaDeDoisPinos t2 = new AdapterTomada(tomadaDe3);
            t2.LigarTomadaDeDoisPinos();

            Console.ReadKey();
        }
    }

    public class TomadaDeDoisPinos
    {
        public virtual void LigarTomadaDeDoisPinos()
        {
            Console.WriteLine("Ligado na tomada de dois pinos");
        }
    }

    public class TomadaDeTresPinos
    {
        public void LigarTomadaDeTresPinos()
        {
            Console.WriteLine("Ligar na tomada de três pinos");
        }
    }

    public class AdapterTomada : TomadaDeDoisPinos
    {
        private TomadaDeTresPinos TomadaDeTresPinos { get; set; }

        public AdapterTomada(TomadaDeTresPinos tomadaDeTresPinos)
        {
            TomadaDeTresPinos = tomadaDeTresPinos; 
        }

        public override void LigarTomadaDeDoisPinos()
        {
            TomadaDeTresPinos.LigarTomadaDeTresPinos();
        }
    }
}
