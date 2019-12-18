using SwedbankPay.Sdk.PaymentOrders;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk
{
    internal abstract class ResourceBase
    {
        internal SwedbankPayHttpClient swedbankPayHttpClient;


        internal ResourceBase(SwedbankPayHttpClient swedbankPayHttpClient)
        {
            this.swedbankPayHttpClient = swedbankPayHttpClient;
        }


        internal string GetExpandQueryString<T>(T expandParameter)
            where T : Enum
        {
            var intValue = Convert.ToInt64(expandParameter);
            if (intValue == 0)
                return string.Empty;

            var s = new List<string>();
            foreach (var enumValue in Enum.GetValues(typeof(T)))
            {
                var name = Enum.GetName(typeof(T), enumValue);
                if (expandParameter.HasFlag((T)enumValue) && name != "None" && name != "All")
                    s.Add(name.ToLower());
            }

            var queryString = string.Join(",", s);
            return $"?$expand={queryString}";
        }
    }
}