using System;
using System.Globalization;
using System.Collections.Generic;
namespace Caixa_Eletronico
{
    class Program
    {
        static void Main(string[] args)
        {
            double saldo = 0, deposito = 0, saque = 0;
            List<double> extrato = new List<double>();
            int opcao;

            do
            {
                Console.WriteLine(".............................");
                Console.WriteLine(" Bem vindo ao caixa Eletrônico");
                Console.WriteLine(".............................");
                Console.WriteLine(" 'Opção Menu'");
                Console.WriteLine(".............................");
                Console.WriteLine(" 1 Saldo\n 2 Extrato\n 3 Deposito\n 4 Saque\n 5 sair ");
                Console.WriteLine(".............................");
                Console.Write(" Digite a opção desejada: ");

                // Validar a entrada do usuário para garantir que é um número inteiro válido
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 5)
                {
                    Console.WriteLine("Entrada inválida. Por favor, digite uma opção válida (1-5).");
                }
                NewMethod(ref saldo, ref deposito, ref saque, extrato, opcao);
            } while (opcao != 5);

        }

        private static void NewMethod(ref double saldo, ref double deposito, ref double saque, List<double> extrato, int opcao)
        {
            NewMethod1(ref saldo, ref deposito, ref saque, extrato, opcao);
        }

        private static void NewMethod1(ref double saldo, ref double deposito, ref double saque, List<double> extrato, int opcao)
        {
            switch (opcao)
            {
                case 1:
                    Console.WriteLine("Saldo atual:R$ " + saldo.ToString("F2"));
                    break;

                case 2:
                    Console.WriteLine("Extrato:");
                    if (extrato.Count == 0)
                    {
                        Console.WriteLine("Não há transações para exibir.");
                    }
                    else
                    {
                        foreach (double transacao in extrato)
                        {
                            Console.WriteLine(transacao.ToString("F2"));
                        }
                    }
                    break;

                case 3:
                    Console.Write("Digite o valor para deposito:R$ ");
                    deposito = double.Parse(Console.ReadLine());

                    saldo += deposito;
                    extrato.Add(deposito);
                    Console.WriteLine("Depósito realizado com suceso.Novo saldo: R$ " + saldo.ToString("F2"));
                    break;

                case 4:
                    Console.Write("Digite o valor para saque:R$ ");

                    // Validar a entrada do usuário para garantir que é um número válido e que o saldo é suficiente
                    while (!double.TryParse(Console.ReadLine(), out saque) || saque <= 0 || saque > saldo)
                    {
                        if (saque > saldo)
                        {
                            Console.WriteLine("Saldo insuficiente. Por favor, digite um valor válido para saque.");
                        }
                        else
                        {
                            Console.WriteLine("Entrada inválida. Por favor, digite um valor válido para saque.");
                        }
                    }

                    saldo -= saque;
                    extrato.Add(-saque);
                    Console.WriteLine("Saque realizado com sucesso. Novo saldo: R$ " + saldo.ToString("F2"));
                    break;

                case 5:
                    Console.WriteLine("Obrigado por utilizar nosso caixa eletrônico. Volte sempre!");
                    break;

                default:
                    Console.WriteLine("Opção inválida. Por favor, escolha uma opção válida.");
                    break;
            }
        }
    }
}
