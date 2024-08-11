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
        private string ativo;
        private double precoVenda;
        private double precoCompra;
        private List<Email> emails = new List<Email>();

        public Observer (string[] valores)
        {
            this.ativo = valores[0];
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

        public void Notificar ()
        {
            return;
        }

    }
}