using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Microsoft.Extensions.Logging;

using SwedbankPay.Sdk.Exceptions;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk
{
    public abstract class ResourceBase
    {
        protected readonly SwedbankPayOptions swedbankPayOptions;
        internal SwedbankPayHttpClient swedbankPayClient;


        internal ResourceBase(
            SwedbankPayOptions swedbankPayOptions,
            ILogger logger,
            HttpClient client)
        {
            if (client == null) //TODO move checks elsewhere
                throw new ArgumentNullException(nameof(client));

            if (swedbankPayOptions == null)
                throw new ArgumentNullException(nameof(swedbankPayOptions));

            if (client.BaseAddress == null || !client.DefaultRequestHeaders.Contains("Authorization"))
                throw new ArgumentException("Invalid client configuration. Check config.");

            if (swedbankPayOptions.IsEmpty())
                throw new InvalidConfigurationSettingsException("Invalid configuration. Check config.");

            this.swedbankPayOptions = swedbankPayOptions;
            this.swedbankPayClient = new SwedbankPayHttpClient(client, logger);
        }


        public async Task<string> GetRaw(string id, PaymentOrderExpand paymentOrderExpand)
        {
            var expandQueryString = GetExpandQueryString(paymentOrderExpand);
            var url = $"{id}?$expand={expandQueryString}";

            return await this.swedbankPayClient.GetRaw(url);
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