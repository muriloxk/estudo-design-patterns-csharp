using System;
namespace ChainOfResponsability.Exercicio
{
    public class CriarReposta
    {
        public string GerarResposta(Requisicao requisicao)
        {
            var respostaJson = new RespostaJSON();
            var respostaPorcento = new RespostaPorcento(respostaJson);
            var respostaCsv = new RespostaCSV(respostaPorcento);
            var respostaXml = new RespostaXML(respostaCsv);


            return respostaXml.GerarResposta(requisicao);
        }
    }
}
