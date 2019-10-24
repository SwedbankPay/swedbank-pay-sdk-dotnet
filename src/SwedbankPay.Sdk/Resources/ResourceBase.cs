namespace SwedbankPay.Sdk.Resources
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using RestSharp;
    using RestSharp.Authenticators;
    using SwedbankPay.Sdk.Exceptions;
    using SwedbankPay.Sdk.Models;

    public abstract class ResourceBase
    {
        protected readonly SwedbankPayOptions SwedbankPayOptions;
        private readonly ILogSwedbankPayHttpResponse _logger;

        internal ResourceBase(SwedbankPayOptions swedbankPayOptions, ILogSwedbankPayHttpResponse logger)
        {
            SwedbankPayOptions = swedbankPayOptions;
            _logger = logger;
        }

        public async Task<string> GetRaw(string id, PaymentOrderExpand paymentOrderExpand)
        {
            var expandQueryString = GetExpandQueryString(paymentOrderExpand);
            var url = $"{id}?$expand={expandQueryString}";
         
            return await CreateInternalClient().GetRaw(url);
        }

        internal SwedbankPayHttpClient CreateInternalClient()
        {
            if (SwedbankPayOptions.IsEmpty())
            {
                throw new InvalidConfigurationSettingsException($"Invalid configuration. Check config.");
            }


            var client = new RestClient(new Uri(SwedbankPayOptions.ApiBaseUrl.ToString()))
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(SwedbankPayOptions.Token, "Bearer")
            };

            return new SwedbankPayHttpClient(client, _logger);
        }


        internal string GetExpandQueryString<T>(T expandParameter) where T : Enum
        {
            var intValue = Convert.ToInt64(expandParameter);
            if (intValue == 0)
            {
                return string.Empty;
            }

            List<string> s = new List<string>();
            foreach (var enumValue in Enum.GetValues(typeof(T)))
            {
                var name = Enum.GetName(typeof(T), enumValue);
                if (expandParameter.HasFlag((T)enumValue) && name != "None" && name != "All")
                {
                    s.Add(name.ToLower());
                }
            }

            var queryString = string.Join(",", s);
            return $"?$expand={queryString}";
        }
    }
}
