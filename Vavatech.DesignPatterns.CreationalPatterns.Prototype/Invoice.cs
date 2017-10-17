using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CreationalPatterns.Prototype
{
    class Invoice : ICloneable
    {
        public string Number { get; set; }

        public DateTime CreateDate { get; set; }

        public Customer Customer { get; set; }

        public decimal TotalAmount { get; set; }

        // ręczna kopia
        //public object Clone()
        //{
        //    Invoice copyInvoice = new Invoice();
        //    copyInvoice.CreateDate = this.CreateDate;
        //    copyInvoice.Number = this.Number;
        //    copyInvoice.Customer = this.Customer;

        //    return copyInvoice;
        //}

        public object Clone()
        {
            // płytka kopia (shallow copy)
            return this.MemberwiseClone();
        }
    }

    class Customer
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

    }



}
