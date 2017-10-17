using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.SOLID.ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            ICashMachine cashMachine = new MyCashMachine();

            cashMachine.Deposit(100);

            var saldo = cashMachine.Saldo();

            Console.WriteLine($"Saldo: {saldo:C2}");



        }
    }
}
