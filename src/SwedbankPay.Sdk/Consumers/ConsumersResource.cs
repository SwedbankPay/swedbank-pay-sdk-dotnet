using System;
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
        ///     Retrieve Consumer Billing Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers billing details with the url
        ///     received through the event OnBillingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<BillingDetails> GetBillingDetails(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            return GetBillingDetailsInternalAsync(url);
        }

        /// <summary>
        ///     Retrieve Consumer Billing Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers billing details with the url
        ///     received through the event OnBillingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<BillingDetails> GetBillingDetailsInternalAsync(Uri url)
        {
            return await this.swedbankPayHttpClient.HttpGet<BillingDetails>(url);
        }

        /// <summary>
        ///     Retrieve Consumer Shipping Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers shipping details with the url
        ///     received through the event onShippingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<ShippingDetails> GetShippingDetails(Uri url)
        {
            if (url == null)
                throw new ArgumentNullException(nameof(url));

            return GetShippingDetailsInternalAsync(url);
        }

        /// <summary>
        ///     Retrieve Consumer Shipping Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers shipping details with the url
        ///     received through the event onShippingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<ShippingDetails> GetShippingDetailsInternalAsync(Uri url)
        {
            return await this.swedbankPayHttpClient.HttpGet<ShippingDetails>(url);
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
    }
}