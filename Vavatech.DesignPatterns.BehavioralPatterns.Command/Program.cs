using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.BehavioralPatterns.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var vm = new ViewModel();

            if (vm.SendCommand.CanExecute())
            {
                vm.SendCommand.Execute();
            }

            vm.StartCommand.Execute();

            vm.StopCommand.Execute();
        }
    }


    class ViewModel
    {
        public Device Device { get; set; }

        public ICommand StartCommand => new StartCommand(this.Device);

        public ICommand StopCommand => new StopCommand(this.Device);

        public ICommand SendCommand => new RelayCommand(() => Send());

        public ViewModel()
        {
            var device = new Device();
        }


        public void Send()
        {
            Console.WriteLine("Send");
        }

        public bool CanSend()
        {
            return Device.IsOn;
        }


    }

    interface ICommand
    {
        void Execute();

        bool CanExecute();
    }


    class Device
    {
        public bool IsOn { get; private set; }

        public void SetOn()
        {
            IsOn = true;

            DoWork();
        }

        public void SetOff()
        {
            IsOn = false;
        }


        private void DoWork()
        {

        }

    }


    class RelayCommand : ICommand
    {
        private Action execute;
        private Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute()
        {
            return canExecute == null || canExecute();
        }

        public void Execute()
        {
            execute();
        }
    }

    class StartCommand : ICommand
    {
        private readonly Device device;

        public StartCommand(Device device)
        {
            this.device = device;
        }

        public bool CanExecute()
        {
            return device.IsOn == false;
        }

        public void Execute()
        {
            device.SetOn();
        }
    }

    class StopCommand : ICommand
    {
        private readonly Device device;

        public StopCommand(Device device)
        {
            this.device = device;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            device.SetOff();
        }
    }


}