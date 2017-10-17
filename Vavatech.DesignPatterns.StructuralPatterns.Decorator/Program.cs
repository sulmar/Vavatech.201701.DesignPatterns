using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.StructuralPatterns.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {

            Control control = new ButtonDecorator(new BorderDecorator(new Button()));

            control.Draw();

            // StreamDecorator();

        }

        private static void StreamDecorator()
        {
            // Odczyt

            Stream stream1 = new FileStream("input.txt", FileMode.Open);

            byte[] buffer1 = new byte[100];

            stream1.Read(buffer1, 0, buffer1.Length);

            string content = System.Text.Encoding.ASCII.GetString(buffer1);

            stream1.Close();


            // Compress

            Stream stream2 = new GZipStream(new FileStream("output.txt", FileMode.Create), CompressionMode.Compress);

            byte[] buffer2 = Encoding.ASCII.GetBytes(content);

            stream2.Write(buffer2, 0, buffer2.Length);

            stream2.Close();


            // Decompress
            Stream stream3 = new GZipStream(new FileStream("output.txt", FileMode.Open), CompressionMode.Decompress);

            byte[] buffer3 = new byte[100];

            stream3.Read(buffer3, 0, buffer3.Length);

            string content3 = System.Text.Encoding.ASCII.GetString(buffer3);

            stream3.Close();
        }
    }


    interface Control
    {
        void Draw();
    }

    public class Button : Control
    {
        public void Draw()
        {
            Console.WriteLine("Button");
        }
    }

    abstract class Decorator : Control
    {
        private Control control;

        public Decorator(Control control)
        {
            this.control = control;
        }

        public virtual void Draw()
        {
            control.Draw();
        }
    }


    class ButtonDecorator : Decorator
    {
        public ButtonDecorator(Control control) 
            : base(control)
        {
        }

        public override void Draw()
        {
            base.Draw();

            Console.WriteLine("Button decorator");
        }
    }

    class BorderDecorator : Decorator
    {
        public BorderDecorator(Control control) : base(control)
        {
        }

        public override void Draw()
        {
            base.Draw();

            Console.WriteLine("Border");
        }
    }

}
