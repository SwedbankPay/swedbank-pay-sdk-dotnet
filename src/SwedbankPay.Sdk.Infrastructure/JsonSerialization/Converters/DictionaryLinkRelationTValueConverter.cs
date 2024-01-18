using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.JsonSerialization.Converters;

public class DictionaryLinkRelationTValueConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(IPaymentOrderResponse);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        var keyType = typeToConvert.GetGenericArguments()[0];
        var valueType = typeToConvert.GetGenericArguments()[1];

        var converter = (JsonConverter)Activator.CreateInstance(
            typeof(CustomPaymentOrderOperationsConverter).MakeGenericType(keyType, valueType),
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: new object[] { options },
            culture: null)!;

        return converter;
    }
}