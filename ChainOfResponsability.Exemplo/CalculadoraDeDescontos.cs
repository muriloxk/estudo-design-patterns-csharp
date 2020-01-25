using System;

namespace ChainOfResponsability.Exemplo
{
    public class CalculadoraDeDescontos
    {
        public double Calcular(Orcamento orcamento)
        {
           var descontoAcimaDeQuinhetos = new DescontoAcimaDeQuinhetos();
           var descontoAcimaDeCincoItems = new DescontoPorMaisDeCincoItens();
           var descontoVendaCasada = new DescontoPorVendaCasada();
           var semDesconto = new SemDesconto();

           descontoAcimaDeCincoItems.Proximo = descontoVendaCasada;
           descontoVendaCasada.Proximo = descontoAcimaDeQuinhetos;
           descontoAcimaDeQuinhetos.Proximo = semDesconto;

           return descontoAcimaDeQuinhetos.Calcular(orcamento);
        }
    }
}
