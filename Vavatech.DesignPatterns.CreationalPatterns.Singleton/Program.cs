using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CreationalPatterns.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {

            Settings settings1 = Singleton<Settings>.Instance;

            Settings settings2 = Singleton<Settings>.Instance;

            if (settings1 == settings2)
            {
                Console.WriteLine("Identyczne");
            }
            else
            {
                Console.WriteLine("Różne");
            }

            // 1 część aplikacji

            Singleton instance1 = Singleton.Instance;

            Singleton instance2 = Singleton.Instance;

            if (instance1 == instance2)
            {
                Console.WriteLine("Identyczne");
            }
            else
            {
                Console.WriteLine("Różne");
            }


            // DoWork


            Console.WriteLine(Singleton<Settings>.Instance.Timeout);
            Console.WriteLine(Singleton<Settings>.Instance.ServiceUrl);
            Console.WriteLine(Singleton<Settings>.Instance.ServiceUrl);


           // Settings settings = new Settings();


        }

        //private static void GetSettings1()
        //{
        //    Settings settings = new Settings();

        //    settings.ServiceUrl = "http://www.vavatech.pl";
        //    settings.Timeout = 30;
        //}

        //private static void GetSettings2()
        //{
        //    Settings settings = new Settings();

        //    settings.ServiceUrl = "http://www.vavatech.pl";
        //    settings.Timeout = 30;
        //}
    }
}
