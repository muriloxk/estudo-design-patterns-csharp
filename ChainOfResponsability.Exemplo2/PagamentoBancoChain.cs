namespace ChainOfResponsability.Exemplo2
{

    public abstract class PagamentoBancoChain
    {
        private PagamentoBancoChain _proximo;
        public PagamentoBancoChain Proximo
        {
            get
            {
                return _proximo;
            }
            set
            {
                if (_proximo == null)
                {
                    _proximo = value;
                    return;
                }

                _proximo.Proximo = value;
            }
        }

        protected EBanco Banco { get; set; }

        public PagamentoBancoChain(EBanco banco)
        {
            Banco = banco;
        }

        public void EfetuarPagamento(Debito debito)
        {
            if (debito.Banco == Banco)
            {
                Pagar(debito);
                return;
            }

            Proximo?.EfetuarPagamento(debito);
        }

        protected abstract void Pagar(Debito debito);
    }
}
