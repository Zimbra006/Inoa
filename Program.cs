/*
    Programa feito para o processo seletivo da Inoa Sistemas.
    Objetivo do programa: 
    - Enviar um alerta, via email, para avisar sobre o preço de uma ação.
    - O nome da ação e os limites de compra/venda serão passados como parâmetros
      na linha de comando.
    - Os emails a serem alertados serão lidos em um arquivo de texto.

    TODO:
    - Ler os parâmetros na linha de comando
    - Obter o valor da ação em tempo real
    - Ler os emails a serem avisados
    - Enviar os emails caso o valor ultrapasse um dos limites

*/

using System;

namespace Inoa
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(args.Length);
        }
    }
}