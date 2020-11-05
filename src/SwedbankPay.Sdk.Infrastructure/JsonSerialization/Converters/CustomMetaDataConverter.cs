using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization.Converters
{
    public class CustomMetaDataConverter : JsonConverter<MetadataResponse>
    {
        public override MetadataResponse Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            var metadata = new MetadataResponse();

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.EndObject)
                {
                    return metadata;
                }

                string keyString = reader.GetString();
                reader.Read();

                if(reader.TokenType == JsonTokenType.String)
                {
                    string itemValue = reader.GetString();

                    if (keyString.Equals(nameof(MetadataResponse.Id), StringComparison.InvariantCultureIgnoreCase))
                        metadata.Id = itemValue;

                    metadata.Add(keyString, itemValue);
                }
                else if (reader.TokenType == JsonTokenType.Number)
                {
                    var value = reader.GetDouble();
                    metadata.Add(keyString, value);
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

        public override void Write(Utf8JsonWriter writer, MetadataResponse value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            foreach (KeyValuePair<string, object> item in value)
            {
                writer.WriteString(item.Key, item.Value.ToString());
            }

            writer.WriteEndObject();
        }
    }
}
