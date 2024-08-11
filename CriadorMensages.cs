/*
    Classe responsável por criar as mensagens que serão
    enviadas aos usuários
*/

namespace Inoa
{
    class CriadorMensagens(string simboloAtivo)
    {
        private readonly string simboloAtivo = simboloAtivo;
        public string CriarMensagem(string tipo, double valor)
        {
            if (tipo == "muitoBaixo")
            {
                return $"O valor de {simboloAtivo} está muito baixo, avaliado em {valor}! Corra para comprar!";
            }

            if (tipo == "baixo")
            {
                return $"O valor de {simboloAtivo} está abaixando, avaliado em {valor}! Compre agora ou espere para ver se ainda vai abaixar mais.";
            }

            if (tipo == "alto")
            {
                return $"O valor de {simboloAtivo} está subindo, avaliado em {valor}! Venda agora, mas ele ainda pode subir mais.";
            }

            if (tipo == "muitoAlto")
            {
                return $"O valor de {simboloAtivo} está muito alto, avaliado em {valor}! Corra para vender!";
            }

            return "";
        }
    }
}