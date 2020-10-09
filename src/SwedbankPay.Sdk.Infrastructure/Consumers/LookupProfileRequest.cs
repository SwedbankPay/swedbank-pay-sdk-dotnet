using SwedbankPay.Sdk.Models.Shared.Consumers;

namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class LookupProfileRequest
    {
        public string Operation { get; set; } = "lookup-profile";

        public NationalIdentifier NationalIdentifier { get; set; }

        public string Email { get; set; }

        public string Msisdn { get; set; }
    }
}
