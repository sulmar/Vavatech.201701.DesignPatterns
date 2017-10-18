using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.DesignPatterns.BehavioralPatterns.Visitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var document = new Document();

            document.Add(new PlainText("Hello"));
            document.Add(new BoldText("Marcin"));
            document.Add(new Hiperlink("Github", "https://github.com/sulmar/Vavatech.201710.DesignPatterns"));
            document.Add(new PlainText("End."));

            IVisitor visitor = new HtmlVisitor();

            document.Accept(visitor);

            Console.WriteLine(visitor.Output);
        }
    }



    abstract class DocumentPart
    {
        public string Text { get; set; }

      //  public abstract string ToHtml();

        public abstract void Accept(IVisitor visitor);
    }

    class PlainText : DocumentPart
    {
        public PlainText(string text)
        {
            this.Text = text;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        //public override string ToHtml()
        //{
        //    return this.Text;
        //}
    }

    class BoldText : DocumentPart
    {
        public BoldText(string text)
        {
            this.Text = text;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        //public override string ToHtml()
        //{
        //    return $"<b>{this.Text}</b>";
        //}
    }

    class Hiperlink : DocumentPart
    {
        public string Url { get; private set; }

        public Hiperlink(string text, string url)
        {
            this.Text = text;
            this.Url = url;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        //public override string ToHtml()
        //{
        //    return $"<a href='{this.Url}'>{this.Text}</a>";
        //}
    }

    class Document
    {
        private IList<DocumentPart> parts = new List<DocumentPart>();

        public void Add(DocumentPart part)
        {
            parts.Add(part);
        }

        public void Accept(IVisitor visitor)
        {
            foreach (var part in parts)
            {
                part.Accept(visitor);
            }
        }

        //public string ToHtml()
        //{
        //    string output = string.Empty;

        //    foreach (var part in parts)
        //    {
        //        output += part.ToHtml();
        //    }

        //    return output;
        //}
    }

    interface IVisitor
    {
        void Visit(PlainText part);
        void Visit(BoldText part);
        void Visit(Hiperlink part);

        string Output { get; }
    }


    class HtmlVisitor : IVisitor
    {
        private string output;
        public string Output
        {
            get
            {
                return output;
            }
        }

        public void Visit(PlainText part)
        {
            output += part.Text;
        }

        public void Visit(BoldText part)
        {
            output += $"<b>{part.Text}</b>";
        }

        public void Visit(Hiperlink part)
        {
            output += $"<a href='{part.Url}'>{part.Text}</a>";
        }
    }

}
