namespace ChainOfResponsability.Exemplo2
{
    public class Debito
    {
        public Debito(EBanco banco, double valor)
        {
            Banco = banco;
            Valor = valor;
        }

        public EBanco Banco { get; set; }
        public double Valor { get; set; }
    }
}