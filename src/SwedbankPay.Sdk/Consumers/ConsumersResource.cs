namespace SwedbankPay.Sdk.Consumers
{
    using RestSharp;

    using SwedbankPay.Sdk.Exceptions;

    using System;
    using System.Threading.Tasks;

    public class ConsumersResource : ResourceBase, IConsumersResource
    {
        public ConsumersResource(SwedbankPayOptions swedbankPayOptions, ILogSwedbankPayHttpResponse logger) : base(swedbankPayOptions, logger)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="consumersRequest"></param>
        /// <returns></returns>
        public async Task<ConsumersResponse> InitiateSession(ConsumersRequest consumersRequest)
        {
            var url = "/psp/consumers";
            
            Func<ProblemsContainer, Exception> onError = m => new CouldNotInitiateConsumerSessionException(consumersRequest, m);
            consumersRequest.Operation = "initiate-consumer-session";
            
            var res = await CreateInternalClient().HttpRequest<ConsumersResponse>(Method.POST, url, onError, consumersRequest);
            return res;
        }
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
