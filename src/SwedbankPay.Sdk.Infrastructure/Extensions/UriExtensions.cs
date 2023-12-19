using System.Globalization;

using SwedbankPay.Sdk.PaymentOrder;

namespace SwedbankPay.Sdk.Infrastructure.Extensions;

public static class UriExtensions
{
    // public static Uri GetUrlWithQueryString(this Uri uri, PaymentExpand paymentExpand)
    // {
    //     var paymentExpandQueryString = GetExpandQueryString<PaymentExpand>(paymentExpand);
    //     var url = !string.IsNullOrWhiteSpace(paymentExpandQueryString)
    //         ? new Uri(uri.OriginalString + paymentExpandQueryString, UriKind.RelativeOrAbsolute)
    //         : uri;
    //     return url;
    // }

    public static Uri GetUrlWithQueryString(this Uri uri, PaymentOrderExpand paymentExpand)
    {
        string paymentExpandQueryString = GetExpandQueryString<PaymentOrderExpand>(paymentExpand);
        var url = !string.IsNullOrWhiteSpace(paymentExpandQueryString)
            ? new Uri(uri.OriginalString + paymentExpandQueryString, UriKind.RelativeOrAbsolute)
            : uri;
        return url;
    }

    private static string GetExpandQueryString<T>(Enum paymentExpand)
        where T : Enum
    {
        var intValue = Convert.ToInt64(paymentExpand);
        if (intValue == 0)
        {
            return string.Empty;
        }

        var s = new List<string>();
        foreach (var enumValue in Enum.GetValues(typeof(T)))
        {
            var name = Enum.GetName(typeof(T), enumValue);
            if (!string.IsNullOrWhiteSpace(name) && paymentExpand.HasFlag((T)enumValue) && name != "None" && name != "All")
            {
                s.Add(name.ToLower(CultureInfo.InvariantCulture));
            }
        }

        var queryString = string.Join(",", s);
        return $"?$expand={queryString}";
    }
}