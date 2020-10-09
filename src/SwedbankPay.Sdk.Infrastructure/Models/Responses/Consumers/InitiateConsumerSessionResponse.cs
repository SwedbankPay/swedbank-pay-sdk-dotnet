using SwedbankPay.Sdk.Models.Requests.Consumers;
using SwedbankPay.Sdk.Models.Shared.Consumers;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Models.Responses.Consumers
{
    public class InitiateConsumerSessionResponse
    {
        public string Token { get; set; }

        public string ConsumerCountryCode { get; set; }

        public RequestInput Input { get; set; }

        public IEnumerable<Operation> Operations { get; set; }

        public IEnumerable<Action> Actions { get; set; }
    }
}
