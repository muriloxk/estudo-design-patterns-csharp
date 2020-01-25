namespace ChainOfResponsability.Exercicio
{
    public class RespostaXML : IResposta
    {
        public RespostaXML(IResposta proxima)
        {
            Proxima = proxima;
        }

        public IResposta Proxima { get; private set; }

        public string GerarResposta(Requisicao requisicao)
        {
            if (requisicao.Formato == EFormato.XML)
                return "Reposta em formato XML";

            return Proxima.GerarResposta(requisicao);
        }
    }
}
