using SwedbankPay.Sdk.JsonSerialization.Converters;
using SwedbankPay.Sdk.PaymentInstruments;
using SwedbankPay.Sdk.PaymentInstruments.Invoice;
using SwedbankPay.Sdk.PaymentOrders;
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

            Settings.Converters.Add(new CustomAmountConverter());
            Settings.Converters.Add(new CustomCurrencyCodeConverter());
            Settings.Converters.Add(new CustomEmailAddressConverter());
            Settings.Converters.Add(new CustomLanguageConverter());
            Settings.Converters.Add(new CustomMsisdnConverter());
            Settings.Converters.Add(new CustomRegionInfoConverter());
            Settings.Converters.Add(new CustomUriConverter());
            Settings.Converters.Add(new CustomMetaDataConverter());
            Settings.Converters.Add(new CustomHttpResponseExceptionConverter());

            // Enum converters
            Settings.Converters.Add(new TypedSafeEnumValueConverter<ShipIndicator>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<DeliveryTimeFrameIndicator>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<PreOrderPurchaseIndicator>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<ReOrderPurchaseIndicator>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<AccountAgeIndicator>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<AccountChangeIndicator>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<AccountPwdChangeIndicator>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<ShippingAddressUsageIndicator>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<ShippingNameIndicator>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<SuspiciousAccountActivity>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<Operation>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<State>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<PaymentOrderLanguage>());
            Settings.Converters.Add(new TypedSafeEnumValueConverter<OrderItemType>());

            // Add all normal enums, to support the "Uknown" value.
            Settings.Converters.Add(new TypesafeEnumConverter<PaymentInstrument>());
            Settings.Converters.Add(new TypesafeEnumConverter<PaymentIntent>());
            Settings.Converters.Add(new TypesafeEnumConverter<PriceType>());
            Settings.Converters.Add(new TypesafeEnumConverter<InvoiceType>());
            Settings.Converters.Add(new TypesafeEnumConverter<TransactionType>());
        }

        public static JsonSerializerOptions Settings { get; private set; }
    }
}