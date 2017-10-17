using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.BehavioralPatterns.Observer
{
    class Program
    {
        static void Main(string[] args)
        {

            var investor1 = new Investor("Marin");
            var investor2 = new Investor("Bartek");

            var stock = new Stock("MSFT", 120.00);

            stock.Attach(investor1);
            stock.Attach(investor2);

            stock.Price = 110;

            stock.Detach(investor1);
            stock.Detach(investor1);

            stock.Price = 90;


        }
    }


    abstract class Subject
    {
        protected IList<IObserver> observers = new List<IObserver>();

        public void Attach(IObserver observer)
        {
            if (!observers.Contains(observer))
            {
                observers.Add(observer);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Detach(IObserver observer)
        {
            if (observers.Contains(observer))
            {
                observers.Remove(observer);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public void Notify()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update(this);
            }
        }
    }

    class Stock : Subject
    {
        private string symbol;

        #region Price

        private double price;

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;

                Notify();
            }
        }

        #endregion

        public Stock(string symbol, double price)
        {
            this.symbol = symbol;
            this.price = price;
        }

        public override string ToString()
        {
            return $"{symbol} - {price:C2}";
        }
    }

    interface IObserver
    {
        void Update(Subject subject);
    }

    class Investor : IObserver
    {
        private string name;

        public Investor(string name)
        {
            this.name = name;
        }

        public void Update(Subject subject)
        {
            Console.WriteLine($"Notified {subject}");
        }
    }


}
