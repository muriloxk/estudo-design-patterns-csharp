using System;
using System.Collections.Generic;

namespace Flyweight.Exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            var notas = new NotasMusicas();

            IList<INotaMusical> musica = new List<INotaMusical>()
            {
                notas.BuscarNota("Re"),
                notas.BuscarNota("Mi"),
                notas.BuscarNota("Fa"),
                notas.BuscarNota("So"),
                notas.BuscarNota("La"),
            };

            var piano = new Piano();
            piano.TocarMusica(musica);

            
            Console.ReadKey();
        }
    }

    public interface INotaMusical
	{
        int Frequencia { get; }
	}

    public class Fa : INotaMusical
    {
        public int Frequencia => 262;
    }

    public class Re : INotaMusical
    {
        public int Frequencia => 120;
    }

    public class Do : INotaMusical
    {
        public int Frequencia => 200;
    }

    public class Mi : INotaMusical
    {
        public int Frequencia => 35;
    }


    public class So : INotaMusical
    {
        public int Frequencia => 100;
    }

    public class La : INotaMusical
    {
        public int Frequencia => 100;
    }

    public class NotasMusicas
    {
        private IDictionary<string, INotaMusical> Notas
            = new Dictionary<string, INotaMusical>()
            {
                { "Re", new Re() },
                { "Mi", new Mi() },
                { "Fa", new Fa() },
                { "Do", new Do() },
                { "So", new So() },
                { "La", new La() }
            };

        public INotaMusical BuscarNota(string nota)
        {
            return Notas[nota];
        }
    }

    public class Piano
    {
        public void TocarMusica(IList<INotaMusical> notas)
        {
            foreach(var nota in notas)
            {
                Console.Beep(nota.Frequencia, 300);
            }
        }
    }
}
