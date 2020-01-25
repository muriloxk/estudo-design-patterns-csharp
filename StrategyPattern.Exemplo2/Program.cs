namespace StrategyPattern.Exemplo2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Aqui deixa o código mais reusavel para outras classes
            // sem precisar de muitas ligações de herança e quando tiver que ter alterações
            // não teremos grandes danos;

            // EXEMPLO BASEADO NO LIVRO HEAD FIRST : DESIGN PATTERNS
            var patoDaCabecaVermelha = new PatoDaCabecaVermelha();
            patoDaCabecaVermelha.ComportamentoDeFalar = new QuackAlto();
            patoDaCabecaVermelha.ComportamentoDeVoar = new VoarComFoguete();

            patoDaCabecaVermelha.Aparecer();
            patoDaCabecaVermelha.Falar();
            patoDaCabecaVermelha.Voar();

            var patoDasMontanhas = new PatoDasMontanhas();
            patoDasMontanhas.ComportamentoDeFalar = new Quack();
            patoDasMontanhas.ComportamentoDeVoar = new VoarComAsas();

            patoDasMontanhas.Aparecer();
            patoDasMontanhas.Falar();
            patoDasMontanhas.Voar();

            var patoDoSitio = new PatoDoSitio();
            patoDoSitio.ComportamentoDeVoar = new NaoVoar();
            patoDoSitio.ComportamentoDeFalar = new Quack();

            patoDoSitio.Aparecer();
            patoDoSitio.Falar();
            patoDoSitio.Voar();
        }
    }
}
