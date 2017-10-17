using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.StructuralPatterns.Adapter
{
    // Target
    interface IRadio
    {
        void Call();
    }

    
    // Adapter

    public class MotorolaAdapter : IRadio
    {
        // Adaptee
        private Motorola motorola;

        public MotorolaAdapter()
        {
            motorola = new Motorola();
        }

        public void Call()
        {
            motorola.Dial();

            motorola.Dispose();
        }
    }

    public class HyteraAdapter : IRadio
    {
        private Hytera hytera;


        public HyteraAdapter()
        {
            hytera = new Hytera();
        }

        public void Call()
        {
            hytera.Init();

            hytera.Call();

            hytera.Release();
        }
    }
}
