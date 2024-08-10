/*
    Classe cujo trabalho é ler o arquivo de configuração com
    as credenciais do servidor SMTP e os emails para enviar
    os avisos e armazená-los para que as outras classes tenham
    acesso.

    Usa as classes Remetente e CredenciaisSTMP definidas em Utils.cs
    para facilitar a leitura.
*/

namespace Inoa
{
    class Leitor
    {   
        private static Leitor instancia = new Leitor();
        private Remetente remetente = new Remetente();
        private CredenciaisSTMP stmp = new CredenciaisSTMP();
        private List<string> emails = new List<string>();


        public static Leitor GetLeitor()
        {
            return instancia;
        }

        public void Ler(string caminho)
        {
            int i = 0;
            foreach (string line in File.ReadLines(@caminho))
            {
                i++;
                if (i > 5) // Após a quinta linha, são só e-mails para enviar os dados
                {
                    emails.Add(line);
                    continue;
                }
                
                if (i == 1) // Email do remetente
                {
                    remetente.email = line;
                }
                else if (i == 2) // Senha do remetente
                {
                    remetente.senha = line;
                }
                else if (i == 3) // Host do servidor STMP
                {
                    stmp.host = line;
                }
                else if (i == 4) // Porta do servido STMP
                {
                    stmp.port = int.Parse(line);
                }
                else if (i == 5) // Flag para usar SSL
                {
                    stmp.ssl = bool.Parse(line);
                }
            }
        }

        public CredenciaisSTMP STMP
        {
            get { return stmp; }
        }

        public Remetente Remetente
        {
            get { return remetente; }
        }

        public List<string> Emails
        {
            get { return emails; }
        }
    }
}