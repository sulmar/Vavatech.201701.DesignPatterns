using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.BehavioralPatterns.Mediator
{
    interface IColleague
    {
        void Send(string message);

        void Receive(string message);

        string Name { get; }
    }


    interface IMediator
    {
        void NotifyAll(string message, IColleague colleague);

        void Attach(IColleague colleague);

        void Detach(IColleague colleague);
    }


    class Mediator : IMediator
    {
        private IList<IColleague> colleagues;

        public Mediator()
        {
            colleagues = new List<IColleague>();
        }

        public void Attach(IColleague colleague)
        {
            colleagues.Add(colleague);
        }

        public void Detach(IColleague colleague)
        {
            colleagues.Remove(colleague);
        }

        public void NotifyAll(string message, IColleague sender)
        {
            foreach (IColleague colleague in colleagues)
            {
                if (colleague == sender) continue;

                colleague.Receive($"{message} from {sender}");
            }
        }
    }

    class Person : IColleague
    {
        private string name;
        private IMediator mediator;

        public string Name
        {
            get { return name; }
        }

        public Person(IMediator mediator, string name = "")
        {
            this.mediator = mediator;
            this.name = name;
        }

        public void Send(string message)
        {
            mediator.NotifyAll(message, this);
        }

        public void Receive(string message)
        {
            Console.WriteLine($"To {this} receive: {message}");
        }

        public override string ToString()
        {
            return Name;
        }

    }
}
