using System;

namespace ByteBank_Program{

	public class VerMenu{

		public void MenuPrincipal()
		{
            Console.Write(">>>>> Bem-Vindo ao <<<<<\n" +
						  ">>>>>>> ByteBank <<<<<<<\n\n" +
						  "1 >> Inserir novo usuario\n" +
						  "2 >> Deletar um usuario\n" +
						  "3 >> Listar todas as contas registradas\n" +
						  "4 >> Detalhes de um usuario\n" +
						  "5 >> Total armazenado no Banco\n" +
						  "6 >> Manipular a conta\n" +
						  "0 >> Sair do Programa\n\n" +
						  "Digite a opcao desejada: ");
		}

		public void SubMenu()
		{
            Console.Write("1 >>> Saque\n" +
                          "2 >>> Depositar\n" +
                          "3 >>> Realizar uma Transferencia\n" +
                          "4 >>> Voltar ao Menu principal\n" +
                          "Digite a opcao desejada: ");
		}

	}
}

