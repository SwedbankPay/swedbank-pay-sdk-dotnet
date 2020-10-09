using SwedbankPay.Sdk.Models.Shared.Consumers;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Models.Responses.Consumers
{
    public class ViewShippingDetailsResponse
    {
        public string Email { get; set; }

        public string Msisdn { get; set; }

        public AddressOperationModel ShippingAddress { get; set; }

        public IEnumerable<Action> Actions { get; set; }
    }
}
