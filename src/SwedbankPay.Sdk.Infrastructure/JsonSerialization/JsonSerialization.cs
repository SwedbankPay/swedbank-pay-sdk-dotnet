using System.Text.Json;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public static class JsonSerialization
    {
        private static JsonSerializerOptions settings = null;

        public static JsonSerializerOptions Settings {
            get
            {
                if (settings == null)
                    CreateJsonSerializerOptions();
                return settings;
            }
        }

        private static void CreateJsonSerializerOptions()
        {
            settings = new JsonSerializerOptions
            {
                IgnoreNullValues = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                MaxDepth = 64,
                IgnoreReadOnlyProperties = false,
            };

            settings.Converters.Add(new CustomAmountConverter());
            settings.Converters.Add(new CustomCurrencyCodeConverter());
            settings.Converters.Add(new CustomEmailAddressConverter());
            settings.Converters.Add(new CustomLanguageConverter());
            settings.Converters.Add(new CustomMsisdnConverter());
            settings.Converters.Add(new CustomRegionInfoConverter());
            settings.Converters.Add(new CustomUriConverter());
        }
    }
}