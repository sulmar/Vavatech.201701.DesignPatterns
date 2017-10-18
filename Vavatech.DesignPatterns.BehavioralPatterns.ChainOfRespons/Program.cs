using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// ChainOfResponsibility
namespace Vavatech.DesignPatterns.BehavioralPatterns.ChainOfRespons
{
    class Program
    {
        static void Main(string[] args)
        {
            var h1 = new ConcreteHandler1();
            var h2 = new ConcreteHandler2();
            var h3 = new ConcreteHandler3();

            h1.SetSuccesor(h2);
            h2.SetSuccesor(h3);

            int[] numbers = { 99, 5, 9, 12, 25 };

            foreach (var number in numbers)
            {
                h1.HandleRequest(number);
            }

        }
    }


    abstract class Handler
    {
        protected Handler succesor;

        public void SetSuccesor(Handler succesor)
        {
            this.succesor = succesor;
        }

        public abstract bool CanRequest(int request);

        public void HandleRequest(int request)
        {
            if (CanRequest(request))
            {
                // Process
                Console.WriteLine($"{this.GetType().Name} handled request {request}");
            }

            else if (succesor!=null)
            {
                succesor.HandleRequest(request);
            }
        }
    }

    class ConcreteHandler1 : Handler
    {
        public override bool CanRequest(int request)
        {
            return request >= 0 && request < 10;
        }
    }

    class ConcreteHandler2 : Handler
    {
        public override bool CanRequest(int request)
        {
            return request >= 10 && request < 20;
        }
    }

    class ConcreteHandler3 : Handler
    {
        public override bool CanRequest(int request)
        {
            return request >= 20 && request < 30;
        }
    }

}
