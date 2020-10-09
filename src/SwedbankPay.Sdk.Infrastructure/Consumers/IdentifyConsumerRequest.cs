using SwedbankPay.Sdk.Models.Shared.Consumers;

namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class IdentifyConsumerRequest
    {
        public string Operation { get; set; } = "identify-consumer";

        public string Msisdn { get; set; }

        public string Email { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }
    }
}
