using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization.Converters;

public class CustomDateTimeConverter : JsonConverter<DateTime>
{
    public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var parsedDateTime = DateTime.Parse(reader.GetString() ?? string.Empty, CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
        return parsedDateTime;
    }

    public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString("O"));
    }
}