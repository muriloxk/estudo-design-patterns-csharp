using System;
using System.Data;

namespace Factory.Exemplo
{
    class Program
    {
        static void Main(String[] args)
        {
            IDbConnection conexao = new FactoryConnection().GetConnection();
            IDbCommand comando = conexao.CreateCommand();
            comando.CommandText = "select * from tabela";

            Console.ReadKey();
        }
    }

 

    public class FactoryConnection
    {
        //Classes SqlConnection e ConfiguracoesArquivo são hipotéticas;
        public IDbConnection GetConnection()
        {
            IDbConnection conexao = new SqlConnection();
            conexao.ConnectionString = new ConfiguracoesArquivo().GetStringConnection();
            conexao.Open();
            return conexao;
        }
    }
}
