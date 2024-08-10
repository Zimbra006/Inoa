/*
    Classe que representa uma entidade a ser notificada,
    no caso, um email.
*/

namespace Inoa
{
    class Email {
        private string endereco;

        public Email(string endereco)
        {
            this.endereco = endereco;
        }

        public void Notificar()
        {
            return;
        }
    }
}