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

            Console.WriteLine(document.ToHtml());
        }
    }


    abstract class DocumentPart
    {
        public string Text { get; set; }

        public abstract string ToHtml();
    }

    class PlainText : DocumentPart
    {
        public PlainText(string text)
        {
            this.Text = text;
        }

        public override string ToHtml()
        {
            return this.Text;
        }
    }

    class BoldText : DocumentPart
    {
        public BoldText(string text)
        {
            this.Text = text;
        }

        public override string ToHtml()
        {
            return $"<b>{this.Text}</b>";
        }
    }

    class Hiperlink : DocumentPart
    {
        private string url;

        public Hiperlink(string text, string url)
        {
            this.Text = text;
            this.url = url;
        }

        public override string ToHtml()
        {
            return $"<a href='{this.url}'>{this.Text}</a>";
        }
    }

    class Document
    {
        private IList<DocumentPart> parts = new List<DocumentPart>();

        public void Add(DocumentPart part)
        {
            parts.Add(part);
        }

        public string ToHtml()
        {
            string output = string.Empty;

            foreach (var part in parts)
            {
                output += part.ToHtml();
            }

            return output;
        }
    }
}
