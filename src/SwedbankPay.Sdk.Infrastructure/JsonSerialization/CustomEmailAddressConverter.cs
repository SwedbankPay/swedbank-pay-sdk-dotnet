using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public class CustomEmailAddressConverter: JsonConverter<EmailAddress>
    {
        public override EmailAddress Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var addressString = reader.GetString();
            return new EmailAddress(addressString);
        }


        public override void Write(Utf8JsonWriter writer, EmailAddress value, JsonSerializerOptions options)
        {
            writer.WriteString(typeof(EmailAddress).Name, value.ToString());
        }
    }
}