using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.BehavioralPatterns.Iterator
{
    class Program
    {
        static void Main(string[] args)
        {
            ConcreteAgregate agregate = new ConcreteAgregate();
            agregate.Add("Marcin");
            agregate.Add("Tomasz");
            agregate.Add("Paweł");
            agregate.Add("Krzysztof");
            agregate.Add("Piotr");


            IIterator iterator = agregate.GetIterator();

            while(!iterator.IsDone())
            {
                Console.WriteLine(iterator.CurrentItem());

                iterator.Next();
            }


        }
    }


    interface IAgregate
    {
        IIterator GetIterator();
    }

    class ConcreteAgregate : IAgregate
    {
        private IList<string> items = new List<string>();

        public IIterator GetIterator()
        {
            return new ConreteIterator(this);
        }

        public object this[int index]
        {
            get
            {
                return items[index];
            }
        }

        public void Add(string item)
        {
            items.Add(item);
        }


        public int Count
        {
            get
            {
                return items.Count;
            }
        }

        public object this[string name]
        {
            get
            {
                return items.SingleOrDefault(x => x == name);
            }
        }
    }

    interface IIterator
    {
        object First();

        object Next();

        object CurrentItem();

        bool IsDone();
    }

    class ConreteIterator : IIterator
    {
        private ConcreteAgregate agregate;

        int position = 0;

        public ConreteIterator(ConcreteAgregate agregate)
        {
            this.agregate = agregate;
        }

        public object CurrentItem()
        {
            if (position < agregate.Count)
            {
                return agregate[position];
            }
            else
            {
                return null;
            }

            
        }

        public object First()
        {
            position = 0;

            return CurrentItem();
        }

        public bool IsDone()
        {
            return position >= agregate.Count;
        }

        public object Next()
        {
            // position++;


            position += 2;

            return CurrentItem();
        }
    }



}
