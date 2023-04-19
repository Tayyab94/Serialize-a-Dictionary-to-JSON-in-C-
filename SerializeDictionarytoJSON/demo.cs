using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializeDictionarytoJSON
{

    public sealed record Person(string FirstName, string LastName)
    {
        public override string ToString() => (FirstName + " " + LastName).Trim();
    }
    public sealed record Customer(string Address, string PhoneNumber, Person Client, Guid CustomerId);
    public sealed record Product(string Name, decimal CostPerItem, Guid ProductId);
    public sealed record InvoiceLineItem(Product Item, int Quantity);
    public sealed record Invoice(DateTime InvoiceDate, Guid InvoiceId, List<InvoiceLineItem> Items);


    public  class Company
    {
        public  Dictionary<Customer, List<Invoice>> GenerateInvoice()
        {
            var customer = new[]
            {
                  new Customer("Pakistan","132123",new Person("Tayyab","Alkas"),Guid.NewGuid())
            };

            var products = new List<Product>
            {
                new("Widget",12.4m,Guid.NewGuid()),
            };

            var invoices = new List<Invoice>
        {
            new(
                DateTime.Now.AddDays(-14),
                Guid.NewGuid(),
                new List<InvoiceLineItem>
                {
                    new(products[0], 10),
                    // Omitted for brevity
                }
            ),
            // Omitted for brevity
        };

            var dictionay = new Dictionary<Customer, List<Invoice>>
            {
                {customer[0],invoices.Take(2).ToList()},
            };

            return dictionay;
        }
    }

    
}
