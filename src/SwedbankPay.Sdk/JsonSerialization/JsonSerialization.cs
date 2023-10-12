using System.Text.Json;
using SwedbankPay.Sdk.JsonSerialization.Converters;

namespace SwedbankPay.Sdk.JsonSerialization;

public static class JsonSerialization
{
    static JsonSerialization()
    {
        Settings = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true,
            MaxDepth = 64,
            IgnoreReadOnlyProperties = false
        };

        Settings.Converters.Add(new CustomDateTimeConverter());
        Settings.Converters.Add(new CustomMetadataDtoConverter());
    }

    public static JsonSerializerOptions? Settings { get; private set; }
}