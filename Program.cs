using System;
using System.Collections.Generic;

namespace transferencia_bancaria
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();
            while (opcaoUsuario.ToUpper() != "x")
            {
                switch (opcaoUsuario)
                 {
                    case "1":
                        ListarContas();
                        break;

                    case "2":
                        InserirConta();
                        break;

                    case "3":
                        Transferir();
                        break;

                    case "4":
                        Sacar();
                        break;

                    case "5":
                        Depositar();
                        break;

                    case "C":
                        Console.Clear();
                        break;

                    default:
                    throw new ArgumentOutOfRangeException();
                }
                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigado por utilizar nossos serviços. ");
            Console.ReadLine();
        }

        private static void Sacar()
        {
            Console.WriteLine("Digite o Numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Valor a ser Sacado: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }

         private static void Depositar()
        {
            Console.WriteLine("Digite o Numero da Conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Valor a ser Depositado: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite o Número da Conta de Origem: ");
            int indeceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Número da Conta de Destino: ");
            int indeceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Valor a Ser Transferido: ");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indeceContaOrigem].Transferir(valorTransferencia, listContas[indeceContaDestino]);
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir Nova Conta");

            Console.WriteLine("Digite 1 para P.F. ou 2 para P.J.: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Nome do Cliente: ");
            string entradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo Inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o Crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
                                        saldo: entradaSaldo,
                                        credito: entradaCredito,
                                        nome: entradaNome);
            listContas.Add(novaConta);
        }
        
        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");

            if (listContas.Count == 0)
            {
                Console.WriteLine("Nenhuma Conta Cadastrada. ");
                return;
            }
            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.WriteLine("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Bank Brothers a seu Dispor!!!");
            Console.WriteLine("Informe a opção desejada: ");

            Console.WriteLine();

            Console.WriteLine("1- Listar Contas");
            Console.WriteLine("2- Inserir Nova Conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C- Limpar a Tela");
            Console.WriteLine("X- Sair");
            Console.WriteLine("");

            string ObterOpcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return ObterOpcaoUsuario;
        }
    }
}
