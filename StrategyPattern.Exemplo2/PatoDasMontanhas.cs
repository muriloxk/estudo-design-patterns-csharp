using System;

namespace StrategyPattern.Exemplo2
{
    public class PatoDasMontanhas : Pato
    {
        public override void Aparecer()
        {
            Console.Write("Apareceu o pato das montanhas");
        }
    }
}
