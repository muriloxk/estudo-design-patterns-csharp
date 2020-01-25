namespace ChainOfResponsability.Exercicio
{
    public class RespostaPorcento : IResposta
    {

        public RespostaPorcento(IResposta proxima)
        {
            Proxima = proxima;
        }

        public IResposta Proxima { get; private set; }

        public string GerarResposta(Requisicao requisicao)
        {
            if (requisicao.Formato == EFormato.PORCENTO)
                return "Reposta em formato separado por porcento";

            return Proxima?.GerarResposta(requisicao);
        }

    }
}
