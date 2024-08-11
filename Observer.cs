/*
    Uma classe seguindo o patter de "Observer" para monitorar
    a ação e notificar uma lista de e-mails
*/

using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;

namespace Inoa
{
    class Observer
    {
        private string simboloAtivo;
        private double precoVenda;
        private double precoCompra;
        private List<Email> emails = new List<Email>();
        private DadosAtivo dadosAtivo = new DadosAtivo();

        // Mensagens diferentes dependendo do valor do ativo
        private Dictionary<string, string> mensagens = new Dictionary<string, string>(4);

        // Uma medida relativa ao tamanho do intervalo entre o preço de compra e de venda
        // Usada para determinar o tipo de mensagem que vai ser enviada aos usuários
        private double limiteFuzzy;
        public Observer (string[] valores)
        {
            simboloAtivo = valores[0];
            precoVenda = Double.Parse(valores[1]);
            precoCompra = Double.Parse(valores[2]);

            limiteFuzzy = (precoVenda - precoCompra) / 4;

            mensagens.Add("muitoBaixo", $"O valor de {simboloAtivo} está muito baixo! Corra para comprar!");
            mensagens.Add("baixo", $"O valor de {simboloAtivo} está abaixando! Compre agora ou espere para ver se ainda vai abaixar mais.");
            mensagens.Add("alto", $"O valor de {simboloAtivo} está subindo! Venda agora, mas ele ainda pode subir mais.");
            mensagens.Add("muitoAlto", $"O valor de {simboloAtivo} está muito alto! Corra para vender!");
        }

        public void AdicionarEmail(string endereco)
        {
            emails.Add(new Email(endereco));
        }

        public void RemoverEmail(string endereco)
        {
            emails.Remove(new Email(endereco));
        }

        // Notifica todos os emails na lista com a mensagem passada
        public void Notificar (string mensagem)
        {
            emails.ForEach(email => email.Notificar(mensagem));
        }

        public void Observar()
        {
            while (true)
            {
                Ativo ativo = dadosAtivo.GetPrecoAtivo(simboloAtivo);
                double preco = ativo.regularMarketPrice;

                Console.WriteLine($"Preço de {simboloAtivo}: {preco}" );

                if (preco < (precoCompra - limiteFuzzy))
                {
                    Notificar(mensagens["muitoBaixo"]);
                }
                else if (preco < precoCompra)
                {
                    Notificar(mensagens["baixo"]);
                }
                else if (preco > (precoVenda + limiteFuzzy))
                {
                    Notificar(mensagens["muitoAlto"]);
                }
                else if (preco > precoVenda)
                {
                    Notificar(mensagens["alto"]);
                }

                // Espera 30 minutos até a próxima atualização da cotação
                Thread.Sleep(30*60*1000);
            }
        }

    }
}