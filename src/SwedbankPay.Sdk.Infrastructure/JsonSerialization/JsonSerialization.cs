using SwedbankPay.Sdk.JsonSerialization.Converters;
using System.Text.Json;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public static class JsonSerialization
    {
        static JsonSerialization()
        {
            Settings = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                MaxDepth = 64,
                IgnoreReadOnlyProperties = false
            };

            Settings.Converters.Add(new CustomDateTimeConverter());
            Settings.Converters.Add(new CustomMetadataDtoConverter());
        }

        public static JsonSerializerOptions Settings { get; private set; }
    }
}