using SwedbankPay.Sdk.JsonSerialization.Converters;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentOrders;
using System.Text.Json;

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

            settings.Converters.Add(new CustomAmountConverter());
            settings.Converters.Add(new CustomCurrencyCodeConverter());
            settings.Converters.Add(new CustomEmailAddressConverter());
            settings.Converters.Add(new CustomLanguageConverter());
            settings.Converters.Add(new CustomMsisdnConverter());
            settings.Converters.Add(new CustomRegionInfoConverter());
            settings.Converters.Add(new CustomUriConverter());
            settings.Converters.Add(new CustomMetaDataConverter());
            settings.Converters.Add(new CustomHttpResponseExceptionConverter());

            // Enum converters
            settings.Converters.Add(new TypedSafeEnumValueConverter<ShipIndicator>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<DeliveryTimeFrameIndicator>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<PreOrderPurchaseIndicator>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<ReOrderPurchaseIndicator>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<AccountAgeIndicator>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<AccountChangeIndicator>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<AccountPwdChangeIndicator>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<ShippingAddressUsageIndicator>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<ShippingNameIndicator>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<SuspiciousAccountActivity>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<Operation>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<State>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<PaymentOrderLanguage>());
            settings.Converters.Add(new TypedSafeEnumValueConverter<OrderItemType>());

            // Add all normal enums, to support the "Uknown" value.
            settings.Converters.Add(new TypesafeEnumConverter<PaymentInstrument>());
            settings.Converters.Add(new TypesafeEnumConverter<PaymentIntent>());
            settings.Converters.Add(new TypesafeEnumConverter<PriceType>());
            settings.Converters.Add(new TypesafeEnumConverter<InvoiceType>());
            settings.Converters.Add(new TypesafeEnumConverter<TransactionType>());
        }
    }
}