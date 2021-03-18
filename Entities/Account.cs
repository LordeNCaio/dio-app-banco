using Bank.Enum;
using System;

namespace Bank.Entities
{
    class Account
    {
        protected AccountTypes AccountType;

        protected Person Owner;

        protected double Balance;

        public Account(Person owner, AccountTypes accountType)
        {
            if(owner != null)
            {
                Owner = owner;
                AccountType = accountType;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void PersonalDeposit(double toDeposit)
        {
            if(Owner.GetCurrentMoney() >= toDeposit) 
            {
                Deposit(toDeposit);
                Owner.SetCurrentMoney(Owner.GetCurrentMoney() - toDeposit);
            }            
        }

        public void PersonalWithdraw(double toWithdraw)
        {
            if (Withdraw(toWithdraw))
            {
                Owner.SetCurrentMoney(Owner.GetCurrentMoney() + toWithdraw);
            }
            
        }

        public void Deposit(double toDeposit)
        {
            Balance += toDeposit;
            Console.WriteLine("O saldo da conta de {0} agora é R${1}", Owner.GetName(),Balance.ToString("N2"));           
        }

        public bool Withdraw(double toWithdraw)
        {
            if(CanWithdraw(toWithdraw))
            {
                Balance -= toWithdraw;
                Console.WriteLine("O saldo da conta de {0} agora é R${1}", Owner.GetName(), Balance.ToString("N2"));
                return true;
            }
            Console.WriteLine("A conta não possui R${0} para sacar", toWithdraw.ToString("N2"));
            return false;
        }

        private bool CanWithdraw(double toWithdraw)
        {
            return (Balance >= toWithdraw);
        }

        public void Transfer(Account destinationAccount, double transferAmount)
        {
            if (CanWithdraw(transferAmount) && destinationAccount != null)
            {
                Console.WriteLine("{0} transferiu R${1} para {2}", GetOwner().GetName(), transferAmount, destinationAccount.GetOwner().GetName());
                destinationAccount.Deposit(transferAmount);
            }
        }

        public double GetBalance() => Balance;
        public Person GetOwner() => Owner;
        public void SetBalance(double value) => Balance = value;
    }
}
