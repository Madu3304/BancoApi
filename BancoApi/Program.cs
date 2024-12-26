using BancoApi.Views;
using static System.Runtime.InteropServices.JavaScript.JSType;


//vetor de armazenamento temporario
List<Conta_view> bancoDados = new List<Conta_view>();

Tela tela = new Tela(ConsoleColor.Green, ConsoleColor.White); //cor de texto e cor de fundo
string opcao;
List<string> menuPrincipal = new List<string>(); 
menuPrincipal.Add("1 - Movimentação     ");
menuPrincipal.Add("2 - Extrato          ");
menuPrincipal.Add("3 - Consultar Conta  ");
menuPrincipal.Add("4 - Boqueio de conta ");
menuPrincipal.Add("5 - Cadastro de Conta");
menuPrincipal.Add("0 - Voltar           ");


tela.configurarTela();
while(true)
{
    tela.montarTelaSistema("Banco PWZ BRASIL");
    opcao = tela.mostrarMenu(menuPrincipal, 3,3);

    if (opcao == "0") break;

    if (opcao == "1")
    {
        tela.montarMoldura(10, 5, 65, 12, "Movimentação");

        Console.SetCursorPosition(11, 7);
        Console.Write("Conta :  ");
        string con = Console.ReadLine();

        bool achou = false;
        int x = 0;

        foreach (Conta_view cta in bancoDados)
        {
            if (cta.NumeroConta == con)
            {
                achou = true;
                break;
            }
        }

        if (achou)
        {
            //se achar a conta, perguntar
            Console.SetCursorPosition(11, 8);
            Console.Write("Deseja Debitar ou Creditar (D/C):  ");
            string tip = Console.ReadLine();

            Console.SetCursorPosition(11, 9);
            Console.Write("Motivo desta ação :  ");
            string moti = Console.ReadLine();

            Console.SetCursorPosition(11, 10);
            Console.Write("Valor :  ");
            decimal val = decimal.Parse(Console.ReadLine());

            Console.SetCursorPosition(11, 11);
            Console.Write("Confirme os dados informados, estão corretos (S/N) :  ");
            Console.SetCursorPosition(11, 11);
            string res = Console.ReadLine().ToUpper();

            if (res == "S")
            {
                if (tip == "D") bancoDados[x].fazerRetirada(val, DateTime.Now, moti);
                if (tip == "C") bancoDados[x].fazerDeposito(val, DateTime.Now, moti);
            }
        }
        else
        {
            Console.SetCursorPosition(11, 8);
            Console.Write("Conta não encontrada. ");
            Console.ReadKey(true);
        }

    }

    if (opcao == "2")
    {
        //Ver extrato
        Console.Clear();
        tela.montarMoldura(0, 0, 79, 2, "EXTRATO");

        Console.SetCursorPosition(1, 3);
        Console.Write("Conta:  ");
        string con = Console.ReadLine();

        //procurando a conta no vetor bancodados
        bool achou = false;
        int x;

        for(x = 0; x < bancoDados.Count; x++)
        {
            if (bancoDados[x].NumeroConta == con)
            {
                achou = true;
                break;
            }
        }

        //mostrar extrato
        if (achou)
        {
            Console.SetCursorPosition(1, 4);
            Console.Write("Titular:  " + bancoDados[x].Titular);
            Console.Write("\n\n");
            Console.Write(bancoDados[x].recuperarExtrato());
            Console.Write("Pressione uma tecla para continuar. ");
            Console.ReadKey(true);


        }
        else
        {
            Console.SetCursorPosition(1, 4);
            Console.Write("Conta não localizada.");

        }


    }


        if (opcao == "3")
        {
        tela.montarMoldura(10, 8, 40, 12, "Consultar contas");

        //perguntar qual o numero da conta está buscando
        Console.SetCursorPosition(11, 10);
        Console.Write("Conta :  ");
        string con = Console.ReadLine();

        //buscador de contas
        string resultado = "Nenhuma conta registrada";
        foreach (Conta_view cta in bancoDados)
        {
            if (cta.NumeroConta == con)
            {
                object ConsultarConta = null;
                resultado = cta.ConsultarConta();
                break;
            }
        }

            Console.SetCursorPosition(11, 12);
            Console.Write(resultado);
            Console.ReadKey();
        }


    if (opcao == "5")
    {
        Console.Clear();
        tela.montarMoldura(7, 7, 40, 12, "NOVA CONTA");

        //Vai perguntar o numero da conta
        Console.SetCursorPosition(9, 9);
        Console.WriteLine("Conta :    ");
        Console.SetCursorPosition(17, 9);
        string con = Console.ReadLine();

        //Vai perguntar o titular da conta
        Console.SetCursorPosition(9, 10);
        Console.WriteLine("Titular :  ");
        Console.SetCursorPosition(19, 10);
        string tit = Console.ReadLine();

        //Vai confirmar os dados informados
        Console.SetCursorPosition(9, 11);
        Console.WriteLine("Confirme seus dados (S/N):  ");
        Console.SetCursorPosition(36, 11);
        string res = Console.ReadLine();

        if (res.ToUpper() == "S")
        {
            //armazenar a conta no banco de dados
            bancoDados.Add( new Conta_view(con, tit));



        }
    }


}