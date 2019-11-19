namespace SwedbankPay.Sdk.Consumers
{
    using Microsoft.Extensions.Logging;

    using RestSharp;

    using SwedbankPay.Sdk.Exceptions;

    using System;
    using System.Threading.Tasks;

    public class ConsumersResource : ResourceBase, IConsumersResource
    {
        public ConsumersResource(SwedbankPayOptions swedbankPayOptions, ILogger logger) : base(swedbankPayOptions, logger)
        {
        }

        /// <summary>
        /// Payer identification is done through this operation. The more information that is provided, the easier an identification process for the payer.
        /// </summary>
        /// <param name="consumersRequest"></param>
        /// <returns></returns>
        public async Task<ConsumersResponse> InitiateSession(ConsumersRequest consumersRequest)
        {
            var url = "/psp/consumers";
            
            Func<ProblemsContainer, Exception> onError = m => new CouldNotInitiateConsumerSessionException(consumersRequest, m);
            var res = await CreateInternalClient().HttpRequest<ConsumersResponse>(Method.POST, url, onError, consumersRequest);
            return res;
        }

        /// <summary>
        /// Retrieve Consumer Shipping Details.
        /// When the payer has been identified through checkin you can retrieve the consumers shipping details with the url received through the event onShippingDetailsAvailable. 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>

        public async Task<ShippingDetails> GetShippingDetails(string url)
        {
            
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException($"{url} Cannot be null or whitespace", paramName: url);
            }
            Func<ProblemsContainer, Exception> onError = m => new CouldNotGetShippingDetailsException(url, m);
            var request = new RestRequest(url, Method.GET);
            
            var shippingDetails = await CreateInternalClient().HttpRequest<ShippingDetails>(Method.GET, url, onError);
            
            return shippingDetails;
        }

        /// <summary>
        /// Retrieve Consumer Billing Details.
        /// When the payer has been identified through checkin you can retrieve the consumers billing details with the url received through the event OnBillingDetailsAvailable. 
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<BillingDetails> GetBillingDetails(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException($"{url} Cannot be null or whitespace", paramName: url);
            }
            Func<ProblemsContainer, Exception> onError = m => new CouldNotGetBillingDetailsException(url, m);
            var request = new RestRequest(url, Method.GET);

            var billingDetails = await CreateInternalClient().HttpGet<BillingDetails>(url, onError);

            return billingDetails;
        }
    }
}
