using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;


namespace BancoApi.Views
{
    public class Tela
    {

        ConsoleColor corTexto, corFundo;


        // construtor,com dados padrões
        public Tela(ConsoleColor ct = ConsoleColor.White,
                    ConsoleColor cf = ConsoleColor.Black)
        {
            corFundo = cf;
            corTexto = ct;

            configurarTela();
        }


        //configuração da tela
        public void configurarTela()
        {
            Console.BackgroundColor = corFundo;
            Console.ForegroundColor = corTexto;
            Console.Clear();
        }


        public void montarTelaSistema(string nome = "Sistema")
        {
            montarMoldura(0, 0, 79, 24);
            montarLinhaHor(2, 0, 79);
            centralizar(1, 0, 79, nome);
        }


        public void montarMoldura(int ci, int li, int cf, int lf, string msg = "")
        {
            int col, lin;

            // limpa a area em que será montada a moldura
            limparArea(ci, li, cf, lf);

            // desenha as linhas horizon
            for (col = ci; col <= cf; col++)
            {
                Console.SetCursorPosition(col, li);
                Console.Write("-");
                Console.SetCursorPosition(col, lf);
                Console.Write("-");
            }

            // desenha as linhas verti
            for (lin = li; lin <= lf; lin++)
            {
                Console.SetCursorPosition(ci, lin);
                Console.Write("|");
                Console.SetCursorPosition(cf, lin);
                Console.Write("|");
            }

            // desenha os cantos da moldura
            Console.SetCursorPosition(ci, li); Console.Write("+");
            Console.SetCursorPosition(ci, lf); Console.Write("+");
            Console.SetCursorPosition(cf, li); Console.Write("+");
            Console.SetCursorPosition(cf, lf); Console.Write("+");

            if (msg != "")
            {
                centralizar(li + 1, ci, cf, msg);
            }
        }


        public void limparArea(int ci, int li, int cf, int lf)
        {
            int col, lin;
            // para cada coluna
            for (col = ci; col <= cf; col++)
            {
                // em cada uma das linahs
                for (lin = li; lin <= lf; lin++)
                {
                    // posiciona
                    Console.SetCursorPosition(col, lin);
                    // imprime 1 espaço em branco para "limpar"
                    Console.Write(" ");
                }
            }
        }


        public void montarLinhaHor(int lin, int ci, int cf)
        {
            int col;
            // traça a linha
            for (col = ci; col <= cf; col++)
            {
                Console.SetCursorPosition(col, lin);
                Console.Write("-");
            }
            // arruma as pontas
            Console.SetCursorPosition(ci, lin);
            Console.Write("+");
            Console.SetCursorPosition(cf, lin);
            Console.Write("+");
        }


        public void centralizar(int lin, int ci, int cf, string msg)
        {
            int col;
            col = ci + (cf - ci - msg.Length) / 2;
            Console.SetCursorPosition(col, lin);
            Console.Write(msg);
        }

        public string mostrarMenu(List<string> menu, int ci, int li)
        {
            int cf, lf, x;
            string op;

            // calcula a coluna final e linha final
            cf = ci + menu[0].Length + 1;
            lf = li + menu.Count() + 2;

            // monta a moldura do menu
            montarMoldura(ci, li, cf, lf);

            // mostra as opções do menu
            for (x = 0; x < menu.Count(); x++)
            {
                Console.SetCursorPosition(ci + 1, li + x + 1);
                Console.Write(menu[x]);
            }
            Console.SetCursorPosition(ci + 1, li + x + 1);
            Console.Write("Opção : ");
            op = Console.ReadLine();
            return op;
        }
    }
}

