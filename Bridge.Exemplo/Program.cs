using System;
using System.Text;

namespace Bridge.Exemplo
{
    class Program
    {
        static void Main(string[] args)
        {
            var mensagemAdmEmail = new MensagemParaOAdministrador("Murilo", new EnviaPorEmail());
            mensagemAdmEmail.Envia();
            var mensagemAdmSms = new MensagemParaOAdministrador("Murilo", new EnviaPorSMS());
            mensagemAdmSms.Envia();

            var mensagemClienteEmail = new MensagemParaOCliente("José", new EnviaPorEmail());
            mensagemClienteEmail.Envia();
            var mensagemClienteSMS = new MensagemParaOCliente("José", new EnviaPorSMS());
            mensagemClienteSMS.Envia();

            Console.ReadKey();
        }
    }

    public interface IEnvia
    {
        void Envia(IMensagem mensagem);
    }

    public interface IMensagem
    {
        IEnvia Enviador { get; }
        void Envia();
        string FormatarMensagem();
    }

    public class EnviaPorEmail : IEnvia
    {
        public void Envia(IMensagem mensagem)
        {
            var mensagemParaEnviar = new StringBuilder();
            mensagemParaEnviar.AppendLine("Enviando mensagem por e-mail");
            mensagemParaEnviar.AppendLine(mensagem.FormatarMensagem());
            Console.WriteLine(mensagemParaEnviar.ToString());
        }
    }

    public class EnviaPorSMS : IEnvia
    {
        public void Envia(IMensagem mensagem)
        {
            var mensagemParaEnviar = new StringBuilder();
            mensagemParaEnviar.AppendLine("Enviando mensagem por SMS");
            mensagemParaEnviar.AppendLine(mensagem.FormatarMensagem());
            Console.WriteLine(mensagemParaEnviar.ToString());
        }
    }

    public class MensagemParaOCliente : IMensagem
    {
        private string Nome;
        public IEnvia Enviador { get; private set; }

        public MensagemParaOCliente(string nome, IEnvia enviador)
        {
            Nome = nome;
            Enviador = enviador;
        }

        public void Envia()
        {
            Enviador.Envia(this);
        }

        public string FormatarMensagem()
        {
            return $"Mensagem para o cliente { Nome }";
        }
    }

    public class MensagemParaOAdministrador : IMensagem
    {
        private string Nome;
        public IEnvia Enviador { get; private set; }

        public MensagemParaOAdministrador(string nome, IEnvia enviador)
        {
            Nome = nome;
            Enviador = enviador;
        }

        public void Envia()
        {
            Enviador.Envia(this);
        }

        public string FormatarMensagem()
        {
            return $"Mensagem para o administrador { Nome }";
        }
    }
}
