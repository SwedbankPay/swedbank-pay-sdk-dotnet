using SwedbankPay.Sdk.Exceptions;

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Consumers
{
    internal class ConsumersResource : ResourceBase, IConsumersResource
    {
        public ConsumersResource(SwedbankPayHttpClient swedbankPayHttpClient)
            : base(swedbankPayHttpClient)
        {
        }
        
        /// <summary>
        ///     Payer identification is done through this operation. The more information that is provided, the easier an
        ///     identification process for the payer.
        /// </summary>
        /// <param name="consumersRequest"></param>
        /// <returns></returns>
        public async Task<Consumer> InitiateSession(ConsumersRequest consumersRequest)
        {
            return await Consumer.Initiate(consumersRequest, this.swedbankPayHttpClient);
        }


        /// <summary>
        ///     Retrieve Consumer Shipping Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers shipping details with the url
        ///     received through the event onShippingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<ShippingDetails> GetShippingDetails(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException($"{url} Cannot be null or whitespace", url);

            Exception OnError(ProblemsContainer m)
            {
                return new CouldNotGetShippingDetailsException(url, m);
            }

            var shippingDetails = await this.swedbankPayHttpClient.SendHttpRequestAndProcessHttpResponse<ShippingDetails>(HttpMethod.Get, url, OnError);
            return shippingDetails;
        }


        /// <summary>
        ///     Retrieve Consumer Billing Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers billing details with the url
        ///     received through the event OnBillingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<BillingDetails> GetBillingDetails(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
                throw new ArgumentException($"{url} Cannot be null or whitespace", url);

            Exception OnError(ProblemsContainer m)
            {
                return new CouldNotGetBillingDetailsException(url, m);
            }

            var billingDetails = await this.swedbankPayHttpClient.SendHttpRequestAndProcessHttpResponse<BillingDetails>(HttpMethod.Get, url, OnError);
            return billingDetails;
        }
    }
}