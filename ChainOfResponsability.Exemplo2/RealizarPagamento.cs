namespace ChainOfResponsability.Exemplo2
{
    public class RealizarPagamento
    {
        public void EfetuarPagamento(Debito debito)
        {
            var meiosDePagamento = new PagamentoNuBank();
            meiosDePagamento.Proximo = new PagamentoItau();
            meiosDePagamento.Proximo = new PagamentoBradesco();

            meiosDePagamento.EfetuarPagamento(debito);
        }
    }
}
