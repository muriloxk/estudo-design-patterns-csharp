using System;

namespace StrategyPattern.Exemplo2
{
    public class PatoDoSitio : Pato
    {
        public override void Aparecer()
        {
            Console.Write("Apareceu o pato do sitio");
        }
    }
}
