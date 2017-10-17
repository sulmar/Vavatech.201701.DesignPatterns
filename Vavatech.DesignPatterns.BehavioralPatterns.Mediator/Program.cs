using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.BehavioralPatterns.Mediator
{
    class Program
    {
        static void Main(string[] args)
        {
            IMediator mediator = new Mediator();

            var person1 = new Person(mediator, "Bartek");
            var person2 = new Person(mediator, "Kasia");
            var person3 = new Person(mediator, "Michał");

            mediator.Attach(person1);
            mediator.Attach(person2);
            mediator.Attach(person3);

            person1.Send("Witajcie!");

        }
    }
}
