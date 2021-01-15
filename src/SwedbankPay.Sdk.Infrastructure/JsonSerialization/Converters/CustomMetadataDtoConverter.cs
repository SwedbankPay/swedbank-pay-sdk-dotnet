using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization.Converters
{
    internal class CustomMetadataDtoConverter : JsonConverter<MetadataDto>
    {
        public override MetadataDto Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var metadata = new MetadataDto();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return metadata;
                }

                string keyString = reader.GetString();
                reader.Read();

                if (reader.TokenType == JsonTokenType.String)
                {
                    string itemValue = reader.GetString();

                    if (keyString.Equals(nameof(Metadata.Id), StringComparison.InvariantCultureIgnoreCase))
                    {
                        metadata.Id = itemValue;
                    }

                    metadata.Add(keyString, itemValue);
                }
                else if (reader.TokenType == JsonTokenType.Number)
                {
                    if (reader.TryGetInt64(out var valueInt))
                    {
                        metadata.Add(keyString, valueInt);
                    }
                    else
                    {
                        var value = reader.GetDecimal();
                        metadata.Add(keyString, value);
                    }
                }
                else if (reader.TokenType == JsonTokenType.False)
                {
                    var value = false;
                    metadata.Add(keyString, value);
                }
                else if (reader.TokenType == JsonTokenType.True)
                {
                    var value = true;
                    metadata.Add(keyString, value);
                }
            }

            throw new JsonException("Error Occured in reading MetaData");
        }

        public override void Write(Utf8JsonWriter writer, MetadataDto value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (KeyValuePair<string, object> item in value)
            {
                if (!item.Key.Equals("id", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (Int64.TryParse(item.Value.ToString(), out var integer))
                    {
                        writer.WriteNumber(item.Key, integer);
                    }
                    else if (Double.TryParse(item.Value.ToString(), out var doubleNumber))
                    {
                        writer.WriteNumber(item.Key, doubleNumber);
                    }
                    else
                    {
                        writer.WriteString(item.Key, item.Value.ToString());
                    }
                }
            }

            writer.WriteEndObject();
        }
    }
}
