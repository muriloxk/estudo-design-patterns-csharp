namespace ChainOfResponsability.Exercicio
{
    public class RespostaJSON : IResposta
    {
        public string GerarResposta(Requisicao requisicao)
        {
            return "Resposta em JSON por padrão caso não encontre um formato";
        }
    }
}
