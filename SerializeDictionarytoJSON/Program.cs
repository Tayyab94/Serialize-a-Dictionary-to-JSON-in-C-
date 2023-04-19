// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using SerializeDictionarytoJSON;
using System.Text.Json;
//using System.Text.Json;

Console.WriteLine("Hello, World!");


//Let’s begin by defining a very simple Dictionary containing an inventory of fruit:
var fruits = new Dictionary<string, int>
{
    {"Appli",1 },
    {"apple", 3},
    {"orange", 5},
    {"banana", 7}
};

/*var d= JsonConvert.SerializeObject(fruits);*/ // Newtonsoft
//var d= JsonSerializer.Serialize(fruits); // System.Text.Json

//============ Newtonsoft.Json ============
//{ "apple":3,"orange":5,"banana":7}

//============ System.Text.Json ============
//{"apple":3,"orange":5,"banana":7}


var d = JsonConvert.SerializeObject(fruits, Formatting.Indented);

//JsonSerializer.Serialize(fruitInventory, new JsonSerializerOptions
//{
//    WriteIndented = true
//});

//============ Newtonsoft.Json - Indented ============
//{
//  "apple": 3,
//  "orange": 5,
//  "banana": 7
//}

//============ System.Text.Json - Indented ============
//{
//  "apple": 3,
//  "orange": 5,
//  "banana": 7
//}



//var dd=JsonConvert.SerializeObject(new Company().GenerateInvoice(), Formatting.Indented);


//var dd=System.Text.Json.JsonSerializer.Serialize(new Company().GenerateInvoice(), new JsonSerializerOptions
//{
//    WriteIndented = true,
//});

var systemJsonComplex = System.Text.Json.JsonSerializer.Serialize(new Company().GenerateInvoice(), new JsonSerializerOptions
{
    Converters = { new SystemJsonCustomerInvoiceConverter() },
    WriteIndented = true,
});
int a = 12;
//public Dictionary<Customer, List<Invoice>> GenerateInvoice()
//{
//    var customer = new[]
//    {
//              new Customer("Pakistan","132123",new Person("Tayyab","Alkas"),Guid.NewGuid())
//        };

//    var products = new List<Product>
//        {
//            new("Widget",12.4m,Guid.NewGuid()),
//        };

//    var invoices = new List<Invoice>
//    {
//        new(
//            DateTime.Now.AddDays(-14),
//            Guid.NewGuid(),
//            new List<InvoiceLineItem>
//            {
//                new(products[0], 10),
//                // Omitted for brevity
//            }
//        ),
//        // Omitted for brevity
//    };

//    var dictionay = new Dictionary<Customer, List<Invoice>>
//        {
//            {customer[0],invoices.Take(2).ToList()},
//        };

//    return dictionay;
//}