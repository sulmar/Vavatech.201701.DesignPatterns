using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CreationalPatterns.TemplateMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            var calculator1 = new NoDiscountCalculator();

            var amount = calculator1.Calculate(100);

            var calculator2 = new BirthdayDiscountCalculator(DateTime.Today, 0.2m);


            amount = calculator2.Calculate(100);

        }
    }

    public class NoDiscountCalculator : Calculator
    {
        public override bool CanDiscount(decimal amount)
        {
            return false;
        }

        public override decimal Discount(decimal amount)
        {
            throw new InvalidOperationException();
        }
    }

    public class BirthdayDiscountCalculator : Calculator
    {
        private readonly DateTime birthday;
        private readonly decimal ratio;

        public BirthdayDiscountCalculator(DateTime birthday, decimal ratio)
        {
            this.birthday = birthday;
            this.ratio = ratio;
        }

        public override bool CanDiscount(decimal amount)
        {
            return birthday.Date == DateTime.Today.Date;
        }

        public override decimal Discount(decimal amount)
        {
            return amount * ratio;
        }
    }


    public abstract class Calculator
    {
        public decimal Calculate(decimal amount)
        {
            if (CanDiscount(amount))
            {
                amount = amount - Discount(amount);
            }

            return amount;
        }

        public abstract bool CanDiscount(decimal amount);

        public abstract decimal Discount(decimal amount);
    }
}
