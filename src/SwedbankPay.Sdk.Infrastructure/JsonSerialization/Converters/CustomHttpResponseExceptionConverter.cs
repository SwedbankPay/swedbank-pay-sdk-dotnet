using SwedbankPay.Sdk.Exceptions;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization.Converters
{
    internal class CustomHttpResponseExceptionConverter : JsonConverter<HttpResponseException>
    {
        public override HttpResponseException Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var httpException = new HttpResponseException();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return httpException;
                }

                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();
                    switch (propertyName)
                    {
                        case "HttpResponse":
                            httpException.HttpResponse = JsonSerializer.Deserialize<HttpResponseMessage>(reader.GetString(), options);
                            break;
                        case "ProblemResponse":
                            var dto = JsonSerializer.Deserialize<ProblemDto>(reader.GetString(), options);
                            httpException.ProblemResponse = dto.Map();
                            break;
                        case "HelpLink":
                            httpException.HelpLink = reader.GetString();
                            break;
                    }
                }
            }

            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, HttpResponseException value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            if (value.Data != null)
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