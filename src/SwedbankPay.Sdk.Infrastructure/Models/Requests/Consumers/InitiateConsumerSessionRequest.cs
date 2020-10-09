using SwedbankPay.Sdk.Models.Shared.Consumers;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class InitiateConsumerSessionRequest
    {
        public string Operation { get; set; } = "initiate-consumer-session";

        public string Msisdn { get; set; }

        public string Email { get; set; }

        public bool RequireShippingAddress { get; set; } = true;

        public string Language { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }

        public string ConsumerCountryCode { get; set; }

        public IEnumerable<string> ShippingAddressRestrictedToCountryCodes { get; set; }
    }
}
