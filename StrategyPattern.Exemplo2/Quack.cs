using System;

namespace StrategyPattern.Exemplo2
{
    public class Quack : IComportamentoDeFalar
    {
        public void Falar()
        {
            Console.WriteLine("Quack!");
        }
    }
}
