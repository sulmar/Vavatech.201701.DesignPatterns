using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.CSharp.RxDemo
{
    class Program
    {
        static void Main(string[] args)
        {

            var service = new Service();
            var coffeeService = new CoffeeService();

            var items = service.Get();


            var coffeeItems = coffeeService.Get();

            //foreach (var item in items)
            //{
            //    Console.WriteLine(item);
            //}

            IObservable<int> observableWater = items.ToObservable();
            IObservable<int> observableCoffee = coffeeItems.ToObservable();

            var observable = observableWater
                .Concat(observableCoffee);

            var stream2 = observable
                .Where(item => item > 70);


            stream2.Subscribe(item => Console.WriteLine($"sub1 {item}"));

            observable
               .Where(item => item < 10)
               .Subscribe(item => Console.WriteLine($"sub2 {item}"));



            Console.WriteLine("Press any key to exit.");

            Console.ReadKey();

        }
    }


    public class CoffeeService
    {
        Random random = new Random();

        public IEnumerable<int> Get()
        {
            while (true)
            {
                Thread.Sleep(500);

                yield return random.Next(100);
            }

        }
    }

    public class Service
    {
        Random random = new Random();

        public IEnumerable<int> Get()
        {
            Thread.Sleep(500);

            yield return random.Next(20, 100);

            //yield return 1;

            //yield return 10;

            //yield return 4;

            //yield return 20;

            //yield return 100;

            //yield return 90;
        }
    }
}
