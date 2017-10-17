using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CreationalPatterns.Strategy
{
    class Program
    {
        static void Main(string[] args)
        {

            var calculator1 = new Calculator(new NoDiscountStrategy());

            var amount = calculator1.Calculate(100);

            var calculator2 = new Calculator(new BirthdayDiscountStrategy(DateTime.Today, 0.1m));

            amount = calculator2.Calculate(100);


        }
    }


    class Calculator
    {
        private readonly IStrategy strategy;

        public Calculator(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public decimal Calculate(decimal amount)
        {
            if (strategy.CanDiscount(amount))
            {
                amount = amount - strategy.Discount(amount);
            }

            return amount;
        }
    }


    interface IStrategy
    {
        bool CanDiscount(decimal amount);

        decimal Discount(decimal amount);
    }

    class NoDiscountStrategy : IStrategy
    {
        public bool CanDiscount(decimal amount)
        {
            return false;
        }

        public decimal Discount(decimal amount)
        {
            throw new InvalidOperationException();
        }
    }

    class BirthdayDiscountStrategy : IStrategy
    {
        private readonly DateTime birthday;
        private readonly decimal ratio;

        public BirthdayDiscountStrategy(DateTime birthday, decimal ratio)
        {
            this.birthday = birthday;
            this.ratio = ratio;
        }

        public bool CanDiscount(decimal amount)
        {
            return birthday.Date == DateTime.Today.Date;
        }

        public decimal Discount(decimal amount)
        {
            return amount * ratio;
        }
    }

}
