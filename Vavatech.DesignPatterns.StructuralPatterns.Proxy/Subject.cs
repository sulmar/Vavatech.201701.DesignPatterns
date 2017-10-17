using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.StructuralPatterns.Proxy
{
    abstract class Subject
    {
        public abstract void Request();
    }


    class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Real Request");
        }
    }

    class Proxy : Subject
    {
        private RealSubject realSubject;

        public override void Request()
        {
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }

            realSubject.Request();
        }
    }


}
