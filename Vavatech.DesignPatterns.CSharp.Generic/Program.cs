using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CSharp.Generic
{
    class Program
    {
        static void Main(string[] args)
        {

            Printer<string> printer = new Printer<string>();

            printer.Print("Hello World!");

            string buffer = printer.Get();

            Console.WriteLine(buffer);


            Printer<int> printer2 = new Printer<int>();

            printer2.Print(100);

            Printer<DateTime> printer3 = new Printer<DateTime>();
            printer3.Print(DateTime.Now);





        }
    }
}
