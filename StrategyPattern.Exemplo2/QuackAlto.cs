using System;

namespace StrategyPattern.Exemplo2
{
    public class QuackAlto : IComportamentoDeFalar
    {
        public void Falar()
        {
            Console.WriteLine("Quack alto!");
        }
    }
}
