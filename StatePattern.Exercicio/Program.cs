using System;
using StatePattern.Exercicio.Domain;

namespace StatePattern.Exercicio
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var conta = new Conta("Murilo", 500);
                
                conta.Depositar(500);
                conta.Sacar(1500);
                conta.Sacar(100);
                conta.Depositar(150000);
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }

   



}
