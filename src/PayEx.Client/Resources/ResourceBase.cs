namespace SwedbankPay.Client.Resources
{
    using RestSharp;
    using RestSharp.Authenticators;

    using SwedbankPay.Client.Models;

    using System;

    public abstract class ResourceBase
    {
        private readonly SwedbankPayOptions _swedbankPayOptions;
        private readonly ILogPayExHttpResponse _logger;

        internal ResourceBase(SwedbankPayOptions swedbankPayOptions, ILogPayExHttpResponse logger)
        {
            _swedbankPayOptions = swedbankPayOptions;
            _logger = logger;
        }

        public string GetRaw(string id, PaymentOrderExpand paymentOrderExpand)
        {
            var expandQueryString = Utils.GetExpandQueryString(paymentOrderExpand);
            var url = $"{id}?$expand={expandQueryString}";
         
            return CreateInternalClient().GetRaw(url);
        }

        internal SwedbankPayHttpClient CreateInternalClient()
        {
            var client = new RestClient(new Uri(_swedbankPayOptions.ApiBaseUrl.ToString()))
            {
                Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator(_swedbankPayOptions.Token, "Bearer")
            };

            return new SwedbankPayHttpClient(client, _logger);
        }
    }
}
