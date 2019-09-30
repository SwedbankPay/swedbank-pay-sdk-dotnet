namespace SwedbankPay.Client.Resources
{
    using RestSharp;
    using RestSharp.Authenticators;

    using SwedbankPay.Client.Exceptions;
    using SwedbankPay.Client.Models;

    using System;
    using System.Threading.Tasks;

    public abstract class ResourceBase
    {
        protected readonly SwedbankPayOptions SwedbankPayOptions;
        private readonly ILogPayExHttpResponse _logger;

        internal ResourceBase(SwedbankPayOptions swedbankPayOptions, ILogPayExHttpResponse logger)
        {
            SwedbankPayOptions = swedbankPayOptions;
            _logger = logger;
        }

        public async Task<string> GetRaw(string id, PaymentOrderExpand paymentOrderExpand)
        {
            var expandQueryString = Utils.GetExpandQueryString(paymentOrderExpand);
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
    }
}
