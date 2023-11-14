using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.JsonSerialization.Converters;

public class DictionaryLinkRelationTValueConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(IPaymentOrderResponse);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Type keyType = typeToConvert.GetGenericArguments()[0];
        Type valueType = typeToConvert.GetGenericArguments()[1];

        JsonConverter converter = (JsonConverter)Activator.CreateInstance(
            typeof(CustomPaymentOrderOperationsConverter).MakeGenericType(
                new Type[] { keyType, valueType }),
            BindingFlags.Instance | BindingFlags.Public,
            binder: null,
            args: new object[] { options },
            culture: null)!;

        return converter;
    }
}