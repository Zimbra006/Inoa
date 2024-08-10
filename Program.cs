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
            Leitor leitor = new Leitor("config.txt");

            Console.WriteLine(leitor.Remetente.email);
            Console.WriteLine(leitor.Remetente.senha);
            Console.WriteLine(leitor.STMP.host);
            Console.WriteLine(leitor.STMP.port);
            Console.WriteLine(leitor.STMP.ssl);

            foreach (string e in leitor.Emails)
                Console.WriteLine(e);

            // Inicializar o observador
            Observer observador = new Observer(args);

        }
    }
}