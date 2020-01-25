using System;

namespace StrategyPattern.Exemplo2
{
    public abstract class Pato
    {
        public IComportamentoDeVoar ComportamentoDeVoar { private get; set; }
        public IComportamentoDeFalar ComportamentoDeFalar { private get; set; }

        public void Falar()
        {
            ComportamentoDeFalar.Falar();
        }

        public void Voar()
        {
            ComportamentoDeVoar.Voar();
        }

        public void Nadar()
        {
            Console.WriteLine("Modo de nadar básico");
        }

        public virtual void Aparecer()
        {
            Console.WriteLine("O pato apareceu");
        }
    }
}
