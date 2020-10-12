using SwedbankPay.Sdk.Payments;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Extensions
{
    public static class UriExtensions
    {
        public static Uri GetUrlWithQueryString(this Uri uri, PaymentExpand paymentExpand)
        {
            var paymentExpandQueryString = GetExpandQueryString(paymentExpand);
            var url = !string.IsNullOrWhiteSpace(paymentExpandQueryString)
                ? new Uri(uri.OriginalString + paymentExpandQueryString, UriKind.RelativeOrAbsolute)
                : uri;
            return url;
        }

        private static string GetExpandQueryString(PaymentExpand paymentExpand)
        {
            var intValue = Convert.ToInt64(paymentExpand);
            if (intValue == 0)
                return string.Empty;

            var s = new List<string>();
            foreach (var enumValue in Enum.GetValues(typeof(PaymentExpand)))
            {
                var name = Enum.GetName(typeof(PaymentExpand), enumValue);
                if (paymentExpand.HasFlag((PaymentExpand)enumValue) && name != "None" && name != "All")
                    s.Add(name.ToLower());
            }

            var queryString = string.Join(",", s);
            return $"?$expand={queryString}";
        }
    }
}
