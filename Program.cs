/*
    Programa feito para o processo seletivo da Inoa Sistemas.
    Objetivo do programa: 
    - Enviar um alerta, via email, para avisar sobre o preço de uma ação.
    - O nome da ação e os limites de compra/venda serão passados como parâmetros
      na linha de comando.
    - Os emails a serem alertados serão lidos de um arquivo de texto.

    TODO:
    - Ler os parâmetros na linha de comando (Feito!)
    - Obter o valor da ação em tempo real (Feito...?)
    - Ler os emails a serem avisados (Feito!)
    - Enviar os emails caso o valor ultrapasse um dos limites (Feito!)

    EXTRAS:
    - Adicionar algum tipo de lógica fuzzy aos emails

*/

using System;

namespace Inoa
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria uma instância do Leitor
            Leitor leitor = Leitor.GetLeitor();

            // Lê as informações no arquivo de texto e armazena
            // e mantém elas em todas as instâncias da classe
            leitor.Ler("config.txt");

            // Inicializa o observador e adiciona os emails
            // na sua lista de destinatários
            Observer observador = new Observer(args);
            foreach (string email in leitor.Emails)
                observador.AdicionarEmail(email);
            
            // Permanece rodando até a aplicação ser suspensa
            // Monitora o valor do ativo e notifica os emails na lista
            observador.Observar();
        }
    }
}