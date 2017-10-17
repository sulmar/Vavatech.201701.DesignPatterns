using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CSharp.Generic
{
    class Printer<TItem>
    {
        private TItem buffer;

        public void Print(TItem item)
        {
            buffer = item;
            Console.WriteLine(item);
        }


        public TItem Get()
        {
            return buffer;
        }
    }



    class PrinterInt
    {
        private int buffer;

        public void Print(int item)
        {
            buffer = item;
            Console.WriteLine(item);
        }


        public int Get()
        {
            return buffer;
        }
    }
}
