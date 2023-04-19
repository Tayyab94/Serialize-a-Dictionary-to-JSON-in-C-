

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SerializeDictionarytoJSON
{
    public sealed class NewtonsoftCustomerInvoiceConverter : JsonConverter<Dictionary<Customer, List<Invoice>>>
    {
        public override Dictionary<Customer, List<Invoice>>? ReadJson(JsonReader reader, Type objectType, Dictionary<Customer, List<Invoice>>? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, Dictionary<Customer, List<Invoice>>? value, JsonSerializer serializer)
        {
            if (value is null) return;

            writer.WriteStartObject();
            foreach (var (customer, invoices) in value)
            {
                writer.WritePropertyName($"Customer-{customer.CustomerId:N}");
                writer.WriteStartObject();
                WriteCustomerProperties(writer, customer);
                WriteInvoices(writer, invoices);
                writer.WriteEndObject();
            }
        }

        private static void WriteCustomerProperties(JsonWriter writer, Customer customer)
        {
            writer.WritePropertyName(nameof(customer.Client));
            writer.WriteValue(customer.Client.ToString());
            writer.WritePropertyName(nameof(customer.Address));
            writer.WriteValue(customer.Address);
            writer.WritePropertyName(nameof(customer.PhoneNumber));
            writer.WriteValue(customer.PhoneNumber);
        }

        private static void WriteInvoices(JsonWriter writer, List<Invoice> invoices)
        {
            writer.WritePropertyName("Invoices");
            var jToken = JToken.FromObject(invoices);
            jToken.WriteTo(writer);
        }
    }



}
