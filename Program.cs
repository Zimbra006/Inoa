/*
    Programa feito para o processo seletivo da Inoa Sistemas.
    Objetivo do programa: 
    - Enviar um alerta, via email, para avisar sobre o preço de uma ação.
    - O nome da ação e os limites de compra/venda serão passados como parâmetros
      na linha de comando.
    - Os emails a serem alertados serão lidos de um arquivo de texto.

    TODO:
    - Ler os parâmetros na linha de comando (Feito!)
    - Obter o valor da ação em tempo real
    - Ler os emails a serem avisados (Feito!)
    - Enviar os emails caso o valor ultrapasse um dos limites

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

            Leitor leitor2 = Leitor.GetLeitor();

            Console.WriteLine(leitor2.Remetente.email);
            Console.WriteLine(leitor2.Remetente.senha);
            Console.WriteLine(leitor2.STMP.host);
            Console.WriteLine(leitor2.STMP.port);
            Console.WriteLine(leitor2.STMP.ssl);

            foreach (string e in leitor2.Emails)
                Console.WriteLine(e);

            // Inicializar o observador
            Observer observador = new Observer(args);

        }
    }
}