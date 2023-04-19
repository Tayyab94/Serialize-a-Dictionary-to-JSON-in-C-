using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SerializeDictionarytoJSON
{
    public sealed class SystemJsonCustomerInvoiceConverter : JsonConverter<Dictionary<Customer, List<Invoice>>>
    {


        // Omitted for brevity

        private static void WriteCustomerProperties(Utf8JsonWriter writer, Customer customer)
        {
            writer.WritePropertyName(nameof(customer.Client));
            writer.WriteStringValue(customer.Client.ToString());
            writer.WritePropertyName(nameof(customer.Address));
            writer.WriteStringValue(customer.Address);
            writer.WritePropertyName(nameof(customer.PhoneNumber));
            writer.WriteStringValue(customer.PhoneNumber);
        }

        private static void WriteInvoices(Utf8JsonWriter writer, List<Invoice> invoices)
        {
            writer.WritePropertyName("Invoices");
            writer.WriteStartArray();
            foreach (var invoice in invoices) WriteInvoiceProperties(writer, invoice);
            writer.WriteEndArray();
        }

        private static void WriteInvoiceProperties(Utf8JsonWriter writer, Invoice invoice)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(invoice.InvoiceDate));
            writer.WriteStringValue(invoice.InvoiceDate);
            writer.WritePropertyName(nameof(invoice.InvoiceId));
            writer.WriteStringValue(invoice.InvoiceId);
            writer.WritePropertyName(nameof(invoice.Items));
            writer.WriteStartArray();
            foreach (var lineItem in invoice.Items)
            {
                writer.WriteStartObject();
                WriteLineItem(writer, lineItem);
                writer.WriteEndObject();
            }
            writer.WriteEndArray();
            writer.WriteEndObject();
        }



        private static void WriteLineItem(Utf8JsonWriter writer, InvoiceLineItem lineItem)
        {
            writer.WritePropertyName("Item");
            WriteProductItem(writer, lineItem.Item);
            writer.WritePropertyName(nameof(lineItem.Quantity));
            writer.WriteNumberValue(lineItem.Quantity);
        }

        private static void WriteProductItem(Utf8JsonWriter writer, Product productItem)
        {
            writer.WriteStartObject();
            writer.WritePropertyName(nameof(productItem.Name));
            writer.WriteStringValue(productItem.Name);
            writer.WritePropertyName(nameof(productItem.CostPerItem));
            writer.WriteNumberValue(productItem.CostPerItem);
            writer.WritePropertyName(nameof(productItem.ProductId));
            writer.WriteStringValue(productItem.ProductId);
            writer.WriteEndObject();
        }

        public override Dictionary<Customer, List<Invoice>>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, Dictionary<Customer, List<Invoice>> value, JsonSerializerOptions options)
        {

            writer.WriteStartObject();
            foreach (var (customer, invoices) in value)
            {
                writer.WritePropertyName($"Customer-{customer.CustomerId:N}");
                writer.WriteStartObject();
                WriteCustomerProperties(writer, customer);
                WriteInvoices(writer, invoices);
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
    }


}
