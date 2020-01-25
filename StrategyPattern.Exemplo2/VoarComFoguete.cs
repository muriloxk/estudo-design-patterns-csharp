using System;

namespace StrategyPattern.Exemplo2
{
    public class VoarComFoguete : IComportamentoDeVoar
    {
        public void Voar()
        {
            Console.WriteLine("Voando com um foguete");
        }
    }
}
