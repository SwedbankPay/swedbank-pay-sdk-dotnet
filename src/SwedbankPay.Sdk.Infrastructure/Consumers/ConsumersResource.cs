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

        public Task<BillingDetails> GetBillingDetails(Uri url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            return HttpClient.GetAsJsonAsync<BillingDetails>(url);
        }

        public Task<ShippingDetails> GetShippingDetails(Uri url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            return HttpClient.GetAsJsonAsync<ShippingDetails>(url);
        }

        public async Task<IConsumersResponse> InitiateSession(ConsumersRequest consumersRequest)
        {
            var url = new Uri("/psp/consumers", UriKind.Relative);

            var consumersResponse = await HttpClient.PostAsJsonAsync<ConsumersResponseDto>(url, consumersRequest);

            return new ConsumersResponse(consumersResponse);
        }
    }
}
