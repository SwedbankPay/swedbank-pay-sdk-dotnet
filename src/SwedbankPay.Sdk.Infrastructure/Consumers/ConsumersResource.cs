using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Consumers
{
    public class ConsumersResource : ResourceBase, IConsumersResource
    {
        public ConsumersResource(HttpClient httpClient) : base(httpClient)
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
            {
                throw new ArgumentNullException(nameof(url));
            }

            return GetBillingDetailsInternalAsync(url);
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
            {
                throw new ArgumentNullException(nameof(url));
            }

            return GetShippingDetailsInternalAsync(url);
        }


        /// <summary>
        ///     Payer identification is done through this operation. The more information that is provided, the easier an
        ///     identification process for the payer.
        /// </summary>
        /// <param name="consumersRequest"></param>
        /// <returns></returns>
        public async Task<IConsumersResponse> InitiateSession(ConsumersRequest consumersRequest)
        {
            var url = new Uri("/psp/consumers", UriKind.Relative);

            var consumerResponse = await HttpClient.PostAsJsonAsync<ConsumersResponseDto>(url, consumersRequest);

            return new ConsumersResponse(consumerResponse);
        }


        /// <summary>
        ///     Retrieve Consumer Billing Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers billing details with the url
        ///     received through the event OnBillingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<BillingDetails> GetBillingDetailsInternalAsync(Uri url)
        {
            return HttpClient.GetAsJsonAsync<BillingDetails>(url);
        }


        /// <summary>
        ///     Retrieve Consumer Shipping Details.
        ///     When the payer has been identified through checkin you can retrieve the consumers shipping details with the url
        ///     received through the event onShippingDetailsAvailable.
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public Task<ShippingDetails> GetShippingDetailsInternalAsync(Uri url)
        {
            return HttpClient.GetAsJsonAsync<ShippingDetails>(url);
        }
    }
}
