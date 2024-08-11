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

        public Observer (string[] valores)
        {
            this.simboloAtivo = valores[0];
            this.precoVenda = Double.Parse(valores[1]);
            this.precoCompra = Double.Parse(valores[2]);
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

                if (preco > precoVenda)
                {
                    Notificar("Pode vender!!");
                }
                else if (preco < precoCompra)
                {
                    Notificar("Pode comprar!!");
                }

                // Espera 30 minutos até a próxima atualização da cotação
                Thread.Sleep(30*60*1000);
            }
        }

    }
}