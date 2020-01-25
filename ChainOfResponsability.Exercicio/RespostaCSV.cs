namespace ChainOfResponsability.Exercicio
{
    public class RespostaCSV : IResposta
    {
        public RespostaCSV(IResposta proxima)
        {
            Proxima = proxima;
        }

        public IResposta Proxima { get; private set; }

        public string GerarResposta(Requisicao requisicao)
        {
            if (requisicao.Formato == EFormato.CSV)
                return "Reposta em formato CSV";

            return Proxima.GerarResposta(requisicao);
        }
    }
}
