using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization.Converters
{
    internal class CustomRiskIndicatorDateTime : JsonConverter<DateTime>
    {
        private const string ThreeDSecureDateTimeString = "yyyyMMdd";

        public override DateTime Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            return DateTime.ParseExact(reader.GetString(), ThreeDSecureDateTimeString, CultureInfo.InvariantCulture);
        }

        public override void Write(
            Utf8JsonWriter writer,
            DateTime dateTimeValue,
            JsonSerializerOptions options)
        {
            writer.WriteStringValue(dateTimeValue.ToString(ThreeDSecureDateTimeString, CultureInfo.InvariantCulture));
        }
    }
}
