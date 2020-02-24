using System;

namespace AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            ContinenteFactory africa = new AfricaFactory();
            MundoAnimal mundoAnimal = new MundoAnimal(africa);
            mundoAnimal.ExecutarCadeiaAlimentar();

            ContinenteFactory america = new AmericaFactory();
            MundoAnimal mundoAnimalDaAmerica = new MundoAnimal(america);
            mundoAnimalDaAmerica.ExecutarCadeiaAlimentar();

            Console.ReadKey();
        }
    }

    public abstract class ContinenteFactory
    {
        public abstract Herbivoro CriarHerbivoro();
        public abstract Carnivoro CriarCarnivoro();
    }

    public class AfricaFactory : ContinenteFactory
    {
        public override Carnivoro CriarCarnivoro()
        {
            return new Leao();
        }

        public override Herbivoro CriarHerbivoro()
        {
            return new Coelho();
        }
    }

    public class AmericaFactory : ContinenteFactory
    {
        public override Carnivoro CriarCarnivoro()
        {
            return new Lobo();
        }

        public override Herbivoro CriarHerbivoro()
        {
            return new Bisao();
        }
    }

    public class Coelho : Herbivoro { }

    public class Leao : Carnivoro
    {
        public override void Comer(Herbivoro herbivoro)
        {
            Console.WriteLine($"Leão come { herbivoro.GetType().Name }");
        }
    }

    public class Bisao : Herbivoro { }

    public class Lobo : Carnivoro
    {
        public override void Comer(Herbivoro herbivoro)
        {
            Console.WriteLine($"Lobo come { herbivoro.GetType().Name }");
        }
    }

    // Client
    public class MundoAnimal
    {
        private Herbivoro _herbivoro;
        private Carnivoro _carnivoro;

        public MundoAnimal(ContinenteFactory factory)
        {
            _carnivoro = factory.CriarCarnivoro();
            _herbivoro = factory.CriarHerbivoro();
        }

        public void ExecutarCadeiaAlimentar()
        {
            _carnivoro.Comer(_herbivoro);
        }
    }
}
