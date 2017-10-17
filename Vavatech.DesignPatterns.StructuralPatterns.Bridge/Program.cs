using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.StructuralPatterns.Bridge
{
    class Program
    {
        static void Main(string[] args)
        {

            Device device = new Device();

            device.Implementor = new StartImplementor();

            device.DoWork();

            device.Implementor = new StopImplementor();

            device.DoWork();
        }
    }

    class Device
    {
        private int position;

        protected IImplementor implementor;

        public IImplementor Implementor
        {
            set
            {
                this.implementor = value;
            }
        }


        public virtual void DoWork()
        {
            position = implementor.Operation(position);
        }
    }

    interface IImplementor
    {
        int Operation(int position);
    }

    public class StartImplementor : IImplementor
    {
        public int Operation(int position)
        {
            Console.WriteLine("Start");

            return ++position;
        }
    }

    public class StopImplementor : IImplementor
    {
        public int Operation(int position)
        {
            Console.WriteLine("Stop");

            return --position;
        }
    }


}
