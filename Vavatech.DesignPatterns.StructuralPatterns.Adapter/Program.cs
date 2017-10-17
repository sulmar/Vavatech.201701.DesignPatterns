using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.StructuralPatterns.Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            IRadio radio = new MotorolaAdapter();

            radio.Call();

            radio = new HyteraAdapter();

            radio.Call();


            //var radio = new Hytera();

            //if (radio is Hytera)
            //{
            //    radio.Init();
            //    radio.Call();

            //    radio.Release();
            //}
            //else if (radio is Motorola)
            //{
                
            //}
        }
    }
}
