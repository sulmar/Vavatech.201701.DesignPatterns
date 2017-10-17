using Stateless;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.BehavioralPatterns.State
{
    // Install-Package stateless -Version 3.1.0

    class Program
    {
        static void Main(string[] args)
        {
            var device = new ProxyDevice(new Device());

            Console.WriteLine(device.State);

            device.Start();

            Console.WriteLine(device.State);
            

            Thread.Sleep(TimeSpan.FromSeconds(10));

            Console.WriteLine(device.State);

        }
    }


    class Device
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
    }

   

    class ProxyDevice
    {
        private readonly Device device;

        public ProxyDevice(Device device)
        {
            this.device = device;
        }

        private StateMachine<State, Triger> machine;
        private System.Timers.Timer timer;

        public ProxyDevice()
        {
            machine = new StateMachine<State, Triger>(State.Off);

            machine.Configure(State.Off)
                .Permit(Triger.Start, State.On)
                .OnExit(DoWork1)
                .OnExit(DoWork2);

            machine.Configure(State.On)
                .Permit(Triger.Stop, State.Off)
                .Permit(Triger.ElapsedTime, State.Off)
                .OnEntry(() => timer.Start(), "TimerStart")
                .OnExit(() => Console.WriteLine("switch off"), "switch off");

            string graph = machine.ToDotGraph();

            // http://www.webgraphviz.com/
            Console.WriteLine(graph);


            timer = new System.Timers.Timer(TimeSpan.FromSeconds(5).TotalMilliseconds);
            timer.AutoReset = false;
            timer.Elapsed += Timer_Elapsed;

        }


        private void DoWork1()
        {
            Console.WriteLine("switch on 1");
        }

        private void DoWork2()
        {
            Console.WriteLine("switch on 2");
        }


        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            machine.Fire(Triger.ElapsedTime);
        }

        public State State
        {
            get { return machine.State; }
        }

        public void Start()
        {
            machine.Fire(Triger.Start);
        }

        public void Stop()
        {
            machine.Fire(Triger.Stop);
        }
    }


    enum State
    {
        On,

        Off
    }

    enum Triger
    {
        Start,

        Stop,

        ElapsedTime
    }
}
