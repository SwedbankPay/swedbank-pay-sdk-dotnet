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

        public async Task<BillingDetails> GetBillingDetails(Uri url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            var details = await HttpClient.GetAsJsonAsync<BillingDetailsDto>(url);
            return details.Map();
        }

        public async Task<ShippingDetails> GetShippingDetails(Uri url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            var details = await HttpClient.GetAsJsonAsync<ShippingDetailsDto>(url);
            return details.Map();
        }

        public async Task<IConsumersResponse> InitiateSession(ConsumersRequest consumersRequest)
        {
            var url = new Uri("/psp/consumers", UriKind.Relative);

            var requestDto = new ConsumersRequestDto(consumersRequest);

            var consumersResponse = await HttpClient.PostAsJsonAsync<ConsumersResponseDto>(url, requestDto);

            return new ConsumersResponse(consumersResponse);
        }
    }
}
