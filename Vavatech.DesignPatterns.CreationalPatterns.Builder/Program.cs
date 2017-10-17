using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CreationalPatterns.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            var invoiceBuilder = new InvoiceReportBuilder();

            director.Construct(invoiceBuilder);

            var report = invoiceBuilder.GetReport();
        }
    }
}
