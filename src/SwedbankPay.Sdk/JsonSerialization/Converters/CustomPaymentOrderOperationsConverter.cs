using System.Text.Json;
using System.Text.Json.Serialization;

using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.JsonSerialization.Converters;

internal class CustomPaymentOrderOperationsConverter : JsonConverter<IPaymentOrderOperations>
{
    public override IPaymentOrderOperations? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    public override void Write(Utf8JsonWriter writer, IPaymentOrderOperations value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        foreach (KeyValuePair<LinkRelation, HttpOperation?> item in value)
        {
            writer.WritePropertyName(item.Key.Name);
            
            writer.WriteStartObject();
            writer.WriteString(nameof(item.Value.Href), item.Value?.Href.ToString());
            writer.WriteString(nameof(item.Value.Method), item.Value?.Method.Method);
            writer.WriteString(nameof(item.Value.ContentType), item.Value?.ContentType);
            writer.WriteString(nameof(item.Value.Rel), item.Value?.Rel.Name);
            writer.WriteEndObject();
        }

        writer.WriteEndObject();
    }
}