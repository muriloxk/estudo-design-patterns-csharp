using System;
namespace ChainOfResponsability.Exercicio
{
    public class Requisicao
    {
        public EFormato Formato { get; private set; }

        public Requisicao(EFormato formato)
        {
            Formato = formato;
        }
    }

    public enum EFormato
    {
        XML,
        CSV,
        PORCENTO
    }
}
