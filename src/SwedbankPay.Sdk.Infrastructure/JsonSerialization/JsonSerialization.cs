using SwedbankPay.Sdk.JsonSerialization.Converters;
using SwedbankPay.Sdk.PaymentOrders;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.JsonSerialization
{
    public static class JsonSerialization
    {
        private static JsonSerializerOptions settings = null;

        public static JsonSerializerOptions Settings
        {
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
                IgnoreReadOnlyProperties = false
            };

            // Converts enums to/from strings
            settings.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));

            settings.Converters.Add(new CustomAmountConverter());
            settings.Converters.Add(new CustomCurrencyCodeConverter());
            settings.Converters.Add(new CustomEmailAddressConverter());
            settings.Converters.Add(new CustomLanguageConverter());
            settings.Converters.Add(new CustomMsisdnConverter());
            settings.Converters.Add(new CustomRegionInfoConverter());
            settings.Converters.Add(new CustomUriConverter());
            settings.Converters.Add(new CustomMetaDataConverter());

            // Enum converters
            settings.Converters.Add(new TypedSafeEnumValueConverter<ShipIndicator, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<DeliveryTimeFrameIndicator, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<PreOrderPurchaseIndicator, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<ReOrderPurchaseIndicator, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<AccountAgeIndicator, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<AccountChangeIndicator, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<AccountPwdChangeIndicator, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<ShippingAddressUsageIndicator, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<ShippingNameIndicator, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<SuspiciousAccountActivity, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<Operation, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<State, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<PaymentOrderLanguage, string>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<OrderItemType, string>());
        }
    }
}