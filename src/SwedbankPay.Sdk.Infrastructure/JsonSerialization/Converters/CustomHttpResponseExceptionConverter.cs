using SwedbankPay.Sdk.Exceptions;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization.Converters
{
    public class CustomHttpResponseExceptionConverter : JsonConverter<HttpResponseException>
    {
        public override HttpResponseException Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, HttpResponseException value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if(value.Data != null)
            {
                writer.WriteStringValue(value.Data.ToString());
            }
            if (!string.IsNullOrEmpty(value.HelpLink))
            {
                writer.WriteStringValue(value.HelpLink);
            }
            if (value.HttpResponse != null)
            {
                writer.WriteStringValue(value.HttpResponse.ToString());
            }
            if (value.InnerException != null)
            {
                writer.WriteStringValue(value.InnerException.Message);
            }
            if (!string.IsNullOrEmpty(value.Message))
            {
                writer.WriteStringValue(value.Message);
            }
            if (value.ProblemResponse != null)
            {
                writer.WriteStringValue(value.ProblemResponse.ToString());
            }
            if (!string.IsNullOrEmpty(value.Source))
            {
                writer.WriteStringValue(value.Source);
            }
            if (!string.IsNullOrEmpty(value.StackTrace))
            {
                writer.WriteStringValue(value.StackTrace);
            }
            writer.WriteNumberValue(value.HResult);
            writer.WriteEndObject();
        }
    }
}