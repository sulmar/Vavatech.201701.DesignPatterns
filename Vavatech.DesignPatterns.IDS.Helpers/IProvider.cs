using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.DesignPatternsIDS.Models;

namespace Vavatech.DesignPatterns.IDS.Helpers
{
    public interface IProvider
    {
        void Send(Alert alert);
    }

    public class ConsoleProvider : IProvider
    {
        public void Send(Alert alert)
        {
            Console.WriteLine($"Alert {alert.CreateDate} {alert.Message}");
        }
    }

    public class SmsProvider : IProvider
    {
        public void Send(Alert alert)
        {
            Console.WriteLine($"Send SMS {alert.CreateDate} {alert.Message}");
        }
    }
}
