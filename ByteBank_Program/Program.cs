using System;

namespace ByteBank_Program {

    public class Program {

        static void RegistrarNovoUsuario(List<string> cpfs, List<string> titulares,
            List<string> senhas, List<double> saldos){
            Console.Write("Digite o CPF: ");
            cpfs.Add(Console.ReadLine());
            Console.Write("Digite o Nome: ");
            titulares.Add(Console.ReadLine());
            Console.Write("Digite a Senha: ");
            senhas.Add(Console.ReadLine());
            saldos.Add(0);
        }

        static bool ValidarCpf(List<string> cpfs, string cpf) {

            return cpfs.Contains(cpf);
        }

        static bool ValidarSenha(List<string> senhas, string senha) {

            return senhas.Contains(senha);
        }

        static void DeletarUsuario( List<string> cpfs, List<string> titulares,
            List<string> senhas, List<double> saldos) {

            Console.Write("Digite o CPF: ");
            string cpfParaDeletar = Console.ReadLine();
            int indexParaDeletar = cpfs.FindIndex(cpf => cpf == cpfParaDeletar);

            if (indexParaDeletar == -1)
            {
                Console.WriteLine("\nNão foi possível deletar esta Conta");
                Console.WriteLine("Motivo: Conta não encontrada.");
                return;
            }

            cpfs.Remove(cpfParaDeletar);
            titulares.RemoveAt(indexParaDeletar);
            senhas.RemoveAt(indexParaDeletar);
            saldos.RemoveAt(indexParaDeletar);

            Console.WriteLine("\nConta deletada com sucesso");
        }

        static void ListarTodasAsContas( List<string> cpfs, List<string> titulares,
            List<double> saldos ) {

            if (cpfs.Count <= 0)
            {
                Console.WriteLine("Nenhuma conta para ser apresentada no momento.");
            }
            else
            {
                for (int i = 0; i < cpfs.Count; i++){
                    ApresentaConta(i, cpfs, titulares, saldos);
                }
            }
        }

        static void ApresentaConta ( int index, List<string> cpfs, List<string> titulares,
            List<double> saldos ) {
            Console.WriteLine($"\nCPF = {cpfs[index]} | Titular = {titulares[index]} | " +
                $"Saldo = R${saldos[index]:F2}");
        }

        static void ApresentarUsuario ( List<string> cpfs, List<string> titulares,
            List<double> saldos ) {

            Console.Write("Digite o CPF: ");
            string cpfParaApresentar = Console.ReadLine();
            int indexParaApresentar = cpfs.FindIndex(cpf => cpf == cpfParaApresentar);

            if (indexParaApresentar == -1)
            {
                Console.WriteLine("\nNão foi possível apresentar esta Conta");
                Console.WriteLine("Motivo: Conta não encontrada.");
            }
            else
            {
                ApresentaConta(indexParaApresentar, cpfs, titulares, saldos);
            }

        }

        static void ApresentarValorAcumulado ( List<double> saldos ) {

            Console.WriteLine($"Total acumulado no banco: R${saldos.Sum():F2}");
        }

        static void ApresentarSaque( List<string> cpfs, List<string> titulares,List<double> saldos ) {

            double valorSaque = 0;
            int index = 0;

            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();

            if(ValidarCpf(cpfs, cpf) == true)
            {
                index = cpfs.IndexOf(cpf);
                Console.Write("Digite o valor do Saque: R$ ");
                valorSaque = double.Parse(Console.ReadLine());

                if(valorSaque > saldos[index])
                {
                    Console.WriteLine("\nSaldo insuficiente. Saque" +
                                      "não realizado.\n");
                }
                else{
                    saldos[index] = saldos[index] - valorSaque;
                    Console.WriteLine("\nSaque realizado!\n");

                }
            }
            else{
                Console.WriteLine("\nConta incorreta!\n");
            }

        }

        static void ApresentarDeposito( List<string> cpfs, List<string> titulares,List<double> saldos){

            double valorDeposito = 0;
            int index = 0;

            Console.Write("Digite o CPF: ");
            string cpf = Console.ReadLine();

            if (ValidarCpf(cpfs, cpf) == true)
            {
                index = cpfs.IndexOf(cpf);
                Console.Write("Digite o valor do Deposito: R$ ");
                valorDeposito = double.Parse(Console.ReadLine());

                if (valorDeposito <= 0)
                {
                    Console.WriteLine("\nDeposito não pode ser realizado.\n");
                }
                else
                {
                    saldos[index] = saldos[index] + valorDeposito;
                    Console.WriteLine("\nDeposito realizado!\n");

                }
            }
            else
            {
                Console.WriteLine("\nConta incorreta!\n");
            }
        }

        static void ApresentarTransferencia( List<string> cpfs, List<string> titulares, List<double> saldos ) {

            double valorTrans = 0;
            int index1 = 0, index2 = 0;

            Console.Write("Digite o seu CPF: ");
            string cpf1 = Console.ReadLine();
            if(ValidarCpf(cpfs,cpf1) == true)
            {
                Console.Write("Digite o CPF que receberá a Transferencia: ");
                string cpf2 = Console.ReadLine();
                if (ValidarCpf(cpfs, cpf2) == true){
                    index1 = cpfs.IndexOf(cpf1);
                    index2 = cpfs.IndexOf(cpf2);
                    Console.Write("Digite o valor a ser transferido: R$ ");
                    valorTrans = double.Parse(Console.ReadLine());
                    if(valorTrans > saldos[index1]){
                        Console.WriteLine("\nSaldo insuficiente. Transferencia " +
                            "não realizada.\n");
                    }
                    else{
                        saldos[index1] = saldos[index1] - valorTrans;
                        saldos[index2] = saldos[index2] + valorTrans;
                        Console.WriteLine("\nTransferencia Realizada!\n");
                    }
                }
                else{
                    Console.WriteLine("\nConta incorreta!\n");
                }
            }
            else
            {
                Console.WriteLine("\nConta incorreta!\n");
            }
        }

        static void Login( List<string> cpfs, List<string> titulares,
            List<string> senhas, List<double> saldos ) {

            Console.Write("Digite seu CPF: ");
            string cpf = Console.ReadLine();
            Console.Write("Digite sua Senha: ");
            string senha = Console.ReadLine();

            if(ValidarCpf(cpfs, cpf) == true && ValidarSenha(senhas,senha) == true){

                return;
            }
            Console.WriteLine("\nNúmero da conta ou senha inválidos. Tente novamente.\n");
            new VerMenu().SubMenu();
        }

        static void Main ( string[] args ) {

            List<string> titulares = new List<string>();
            List<string> cpfs = new List<string>();
            List<string> senhas = new List<string>();
            List<double> saldos = new List<double>();

            var menus = new VerMenu();
            int optionMenu;


            do
            {
                menus.MenuPrincipal();
                optionMenu = int.Parse(Console.ReadLine());

                Console.WriteLine("\n------------------------------\n");

                switch (optionMenu)
                {
                    case 0:
                        Console.WriteLine("Encerrando o programa.");
                        break;
                    case 1:
                        RegistrarNovoUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 2:
                        DeletarUsuario(cpfs, titulares, senhas, saldos);
                        break;
                    case 3:
                        ListarTodasAsContas(cpfs, titulares, saldos);
                        break;
                    case 4:
                        ApresentarUsuario(cpfs, titulares, saldos);
                        break;
                    case 5:
                        ApresentarValorAcumulado(saldos);
                        break;
                    case 6:

                      do{
                            menus.SubMenu();
                            optionMenu = int.Parse(Console.ReadLine());

                            switch (optionMenu){
                                case 1:
                                    Login(cpfs, titulares, senhas, saldos);
                                    ApresentarSaque(cpfs, titulares, saldos);
                                    break;
                                case 2:
                                    Login(cpfs, titulares, senhas, saldos);
                                    ApresentarDeposito(cpfs, titulares, saldos);
                                    break;
                                case 3:
                                    Login(cpfs, titulares, senhas, saldos);
                                    ApresentarTransferencia(cpfs, titulares, saldos);
                                    break;
                                case 4:
                                    Console.WriteLine("Voltando ao Menu Principal...");
                                    break;
                            }
                            Console.WriteLine("\n------------------------------\n");

                        } while(optionMenu != 4);
                         break;
                }

                Console.WriteLine("\n------------------------------\n");

            } while (optionMenu != 0);




        }
    }
}