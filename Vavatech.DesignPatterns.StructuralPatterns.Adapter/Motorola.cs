using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.StructuralPatterns.Adapter
{
    // Concrete type

    class Motorola
    {

        public void Dial()
        {
            Console.WriteLine("Dialling...");
        }

        public void Dispose()
        {
        }
    }
}
