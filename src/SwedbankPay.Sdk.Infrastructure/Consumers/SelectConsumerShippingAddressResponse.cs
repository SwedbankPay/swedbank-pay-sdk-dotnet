using SwedbankPay.Sdk.Models.Shared.Consumers;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Models.Responses.Consumers
{
    public class SelectConsumerShippingAddressResponse
    {
        public IEnumerable<Operation> Operations { get; set; }

        public IEnumerable<Action> Actions { get; set; }
    }
}
