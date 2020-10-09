using SwedbankPay.Sdk.Models.Shared.Consumers;

namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class RequestInput
    {
        public string Email { get; set; }

        public string Msisdn { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }
    }
}
