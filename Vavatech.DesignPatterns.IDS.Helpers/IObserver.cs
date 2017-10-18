using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatternsIDS.Models;

namespace Vavatech.DesignPatterns.IDS.Helpers
{

    public interface IObserver<T>
    {
        void Update(T item);
    }

    public interface IAlertObserver : IObserver<Alert>
    {

    }


    public class ConsoleAlertObserver : IAlertObserver
    {
        public void Update(Alert item)
        {
            Console.WriteLine($"Alert {item.CreateDate} {item.Message}");
        }
    }


    public class SmsAlertObserver : IAlertObserver
    {
        public void Update(Alert item)
        {
            Console.WriteLine($"Send SMS {item.CreateDate} {item.Message}");
        }
    }



}
