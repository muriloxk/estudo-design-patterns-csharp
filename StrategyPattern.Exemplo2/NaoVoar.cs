using System;

namespace StrategyPattern.Exemplo2
{
    public class NaoVoar : IComportamentoDeVoar
    {
        public void Voar()
        {
            Console.WriteLine("Não consegue voar");
        }
    }
}
