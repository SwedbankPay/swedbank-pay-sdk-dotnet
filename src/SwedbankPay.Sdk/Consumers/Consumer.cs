using Newtonsoft.Json;
using SwedbankPay.Sdk.Extensions;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwedbankPay.Sdk.Consumers
{
    public class Consumer
    {
        private Consumer(ConsumersResponse consumersResponse)
        {
            ConsumersResponse = consumersResponse;
            var operations = new Operations();

            foreach (var httpOperation in consumersResponse.Operations)
            {
                operations.Add(httpOperation.Rel, httpOperation);

                switch (httpOperation.Rel.Value)
                {
                    case ConsumerResourceOperations.RedirectConsumerIdentification:
                        operations.RedirectConsumerIdentification = httpOperation;
                        break;
                    case ConsumerResourceOperations.ViewConsumerIdentification:
                        operations.ViewConsumerIdentification = httpOperation;
                        break;
                }

                Operations = operations;
            }
        }


        public ConsumersResponse ConsumersResponse { get; }

        public Operations Operations { get; }


        internal static async Task<Consumer> Initiate(ConsumersRequest consumersRequest, HttpClient client)
        {
            var url = new Uri("/psp/consumers", UriKind.Relative);

            var consumerResponse = await client.PostAsJsonAsync<ConsumersResponse>(url, consumersRequest);

            return new Consumer(consumerResponse);
        }
    }
}