using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CreationalPatterns.Builder
{
    
    abstract class ReportBuilder<TReport>
        where  TReport : class, new()
    {
        protected TReport report = new TReport();

        public abstract void BuildHeader();

        public abstract void BuildDetails();

        public abstract void BuildFooter();

        public abstract TReport GetReport();
    }

    abstract class ReportBuilder : ReportBuilder<Report>
    {

    }

    class InvoiceReportBuilder : ReportBuilder
    {
      
        public override void BuildHeader()
        {
            report.Header = $"Faktura z dn. {DateTime.Today.ToShortDateString()}";
        }

        public override void BuildDetails()
        {
            report.Details = new string[]
            {
                "Line 1",
                "Line 2",
                "Line 3"
            };
        }

        public override void BuildFooter()
        {
            report.Footer = "Podsumowanie: ";
        }

       
        public override Report GetReport()
        {
            return report;
        }
    }


    class Director
    {
        public void Construct(ReportBuilder builder)
        {
            builder.BuildHeader();

            builder.BuildDetails();

            builder.BuildFooter();
        }
    }

    // Product
    class Report
    {
        public string Header { get; set; }

        public string[] Details { get; set; }

        public string Footer { get; set; }

    }


}
