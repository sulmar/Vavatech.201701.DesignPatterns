using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CreationalPatterns.Prototype
{
    class Program
    {
        static void Main(string[] args)
        {

            Customer customer = new Customer
            {
                FirstName = "Marcin",
                LastName = "Sulecki"
            };

            Invoice invoice = new Invoice
            { 
                CreateDate = DateTime.Now,
                Number = "FV 001/2017",
                Customer = customer,
                TotalAmount = 999
            };

            Invoice copyInvoice = (Invoice) invoice.Clone();


            Invoice copyInvoice2 = (Invoice)invoice.Clone();

            //Invoice copyInvoice = new Invoice();
            //copyInvoice.CreateDate = invoice.CreateDate;
            //copyInvoice.Number = invoice.Number;
            //copyInvoice.Customer = invoice.Customer;


        }
    }
}
