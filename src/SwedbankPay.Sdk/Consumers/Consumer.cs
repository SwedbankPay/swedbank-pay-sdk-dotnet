using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Consumers
{
    public class Consumer
    {
        private Consumer(ConsumersResponse consumersResponse)
        {
            ConsumersResponse = consumersResponse;
            var operations = new ConsumerOperations(consumersResponse.Operations);
            Operations = operations;
        }


        public ConsumersResponse ConsumersResponse { get; }

        public ConsumerOperations Operations { get; }


        internal static async Task<Consumer> Initiate(ConsumersRequest consumersRequest, HttpClient client)
        {
            var url = new Uri("/psp/consumers", UriKind.Relative);

            var consumerResponse = await client.PostAsJsonAsync<ConsumersResponse>(url, consumersRequest);

            return new Consumer(consumerResponse);
        }
    }
}