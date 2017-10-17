using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CreationalPatterns.AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {

            string expression = "2 3 + 2 *";

            var parser = new Parser(new ExpressionFactory());

            var result = parser.Evaluate(expression);

            Console.WriteLine(result);

        }
    }
}
