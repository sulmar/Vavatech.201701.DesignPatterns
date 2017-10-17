using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.StructuralPatterns.Adapter
{
    // Concrete type

    class Hytera
    {

        public void Init()
        {
        }

        public void Call()
        {
            Console.WriteLine("Calling...");
        }

        public void Release()
        {

        }
    }
}
