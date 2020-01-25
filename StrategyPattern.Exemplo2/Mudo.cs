using System;

namespace StrategyPattern.Exemplo2
{
    public class Mudo : IComportamentoDeFalar
    {
        public void Falar()
        {
            Console.WriteLine("...");
        }
    }
}
