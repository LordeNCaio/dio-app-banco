using Bank.Entities;
using Bank.Enum;
using System;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Person andreClaro = new Person("André Claro", 1200.00);
            Account andreAccount = new Account(andreClaro, AccountTypes.Physical);

            Person stephanie = new Person("Stephanie Vitória", 900.00);
            Account stephanieAccount = new Account(stephanie, AccountTypes.Physical);

            andreAccount.PersonalDeposit(1000);
            Console.WriteLine("{0} seu dinheiro atual é de R${1}\n", andreClaro.GetName(), andreClaro.GetCurrentMoney());

            andreAccount.PersonalWithdraw(200);
            Console.WriteLine("{0} seu dinheiro atual é de R${1}\n", andreClaro.GetName(), andreClaro.GetCurrentMoney());

            stephanieAccount.PersonalDeposit(300);
            Console.WriteLine("{0} seu dinheiro atual é de R${1}\n", stephanie.GetName(), stephanie.GetCurrentMoney());

            andreAccount.Transfer(stephanieAccount, 800);
            Console.WriteLine("\n");

            stephanieAccount.PersonalWithdraw(1000);
            Console.WriteLine("{0} seu dinheiro atual é de R${1}\n", stephanie.GetName(), stephanie.GetCurrentMoney());
        }
    }
}
