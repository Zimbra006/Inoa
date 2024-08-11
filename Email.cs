/*
    Classe que representa uma entidade a ser notificada,
    no caso, um email.
*/

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace Inoa
{
    class Email
    {

        static MailboxAddress remetente;
        static string emailRemetente;
        static string senha;
        static CredenciaisSMTP smtp;
        private MailboxAddress destinatario;

        static Email()
        {
            Leitor leitor = Leitor.GetLeitor();

            emailRemetente = leitor.Remetente.email;
            senha = leitor.Remetente.senha;
            remetente = new MailboxAddress("Notificador", emailRemetente);

            smtp = leitor.SMTP;
        }

        public Email(string endereco)
        {
            this.destinatario = new MailboxAddress("", endereco);
            Console.WriteLine("Email registrado: " + endereco);
        }

        public void Notificar(string mensagem)
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            Console.WriteLine("Enviando...");

            MimeMessage mail = new MimeMessage();

            mail.From.Add(remetente);
            mail.To.Add(destinatario);

            mail.Subject = "Atualização sobre o seu ativo!!";

            mail.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = @$"<h3>Olá, querido investidor.</h3>
                <p> Trazemos uma atualização sobre o seu ativo: </p>
                <h1> <b> {mensagem} </b> </h1>
                <br><br>
                <p>Obrigado por usar nosso produto!</p>
                "
            };

            using (var cliente = new SmtpClient())
            {
                cliente.Connect(smtp.host, smtp.port, smtp.ssl);

                Console.WriteLine("Username: " + emailRemetente);
                Console.WriteLine("Senha: " + senha);
                cliente.Authenticate(emailRemetente, senha);

                try
                {
                    cliente.Send(mail);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                cliente.Disconnect(true);
            }
        }
    }
}