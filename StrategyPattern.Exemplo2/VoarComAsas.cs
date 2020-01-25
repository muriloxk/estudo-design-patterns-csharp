using System;

namespace StrategyPattern.Exemplo2
{
    public class VoarComAsas : IComportamentoDeVoar
    {
        public void Voar()
        {
            Console.WriteLine("Voando com asas");
        }
    }
}
