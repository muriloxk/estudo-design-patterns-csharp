using System;

namespace StrategyPattern.Exemplo2
{
    public class PatoDaCabecaVermelha : Pato
    {
        public override void Aparecer()
        {
            Console.WriteLine("Apareceu o pato da cabeça vermelha");
        }
    }
}
