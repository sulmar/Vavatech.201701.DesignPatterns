using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.SOLID.ISP
{
    class PKOCashMachine : ISaldoCashMachine, IWidthdrawCashMachine
    {
        private decimal saldo;
      

        public decimal Saldo()
        {
            return saldo;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > saldo)
            {
                throw new InvalidOperationException();
            }

            saldo -= amount;

            Console.WriteLine($"{DateTime.Now} Wypłata {amount}");
        }


        public void Print()
        {
            Console.WriteLine("PKO");
        }
    }


    class MyCashMachine : ICashMachine
    {
        private decimal saldo;

        public void Deposit(decimal amount)
        {
            saldo += amount;

            Console.WriteLine($"{DateTime.Now} Wpłata {amount}");
        }

        public decimal Saldo()
        {
            return saldo;
        }

        public void Withdraw(decimal amount)
        {
            if (amount > saldo)
            {
                throw new InvalidOperationException();
            }

            saldo -= amount;

            Console.WriteLine($"{DateTime.Now} Wypłata {amount}");
        }
    }
}
