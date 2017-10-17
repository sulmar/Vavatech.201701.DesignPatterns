using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABW.DesignPatterns.CreationalPatterns.FluentApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var product1 = new Product
            {
                Name = "Rysik",
                Price = 100
            };

            var item1 = new Item
            {
                Product = product1,
                Quantity = 2,
                Amount = 1800
            };

            Invoice
                .Create()
                .Add(item1)
                .Add(item1)
                .Remove(item1);
                

          //  CreateInvoiceTest();



        }

        //private static void CreateInvoiceTest()
        //{
        //    var product1 = new Product
        //    {
        //        Name = "Tablecik",
        //        Price = 999
        //    };

        //    var product2 = new Product
        //    {
        //        Name = "Rysik",
        //        Price = 100
        //    };

        //    var item1 = new Item
        //    {
        //        Product = product1,
        //        Quantity = 2,
        //        Amount = 1800
        //    };

        //    var item2 = new Item
        //    {
        //        Product = product2,
        //        Quantity = 1,
        //        Amount = 100
        //    };

        //    var invoice = new Invoice
        //    {
        //        Number = "FV 001/2017",
        //        CreateDate = DateTime.Now
        //    };

        //    invoice.Items.Add(item1);
        //    invoice.Items.Add(item2);



        //    foreach (var item in invoice.Items)
        //    {
        //        Console.WriteLine(item.Product.Name);
        //    }
        //}
    }

    class Invoice
    {
        public string Number { get; private set; }

        public DateTime CreateDate { get; private set; }

        private IList<Item> Items { get; set; }

        public static Invoice Create()
        {
            return new Invoice()
            {
                Items = new List<Item>()
            };
        }

        public Invoice Add(Item item)
        {
            Items.Add(item);

            return this;
        }

        public Invoice Remove(Item item)
        {
            Items.Remove(item);

            return this;
        }
    }

    class Item
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }
    }

    class Product
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
