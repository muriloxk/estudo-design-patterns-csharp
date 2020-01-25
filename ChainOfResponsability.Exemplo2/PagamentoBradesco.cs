using System;

namespace ChainOfResponsability.Exemplo2
{
    public class PagamentoBradesco : PagamentoBancoChain
    {
        public PagamentoBradesco() : base(EBanco.Bradesco)
        {

        }

        protected override void Pagar(Debito debito)
        {
            Console.WriteLine("Pagamento realizado via Bradesco");
        }
    }
}
