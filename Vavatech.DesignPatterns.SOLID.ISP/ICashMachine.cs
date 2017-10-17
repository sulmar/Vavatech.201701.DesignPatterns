using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.SOLID.ISP
{
    interface ICashMachine : IDepositCashMachine, IWidthdrawCashMachine, ISaldoCashMachine
    {

    }


    interface IDepositCashMachine
    {
        void Deposit(decimal amount);
    }

    interface IWidthdrawCashMachine
    {
        void Withdraw(decimal amount);
    }

    interface ISaldoCashMachine
    {
        decimal Saldo();
    }


}
