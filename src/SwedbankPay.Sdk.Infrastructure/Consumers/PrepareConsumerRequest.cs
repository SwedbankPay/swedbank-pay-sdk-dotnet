using SwedbankPay.Sdk.Models.Shared.Consumers;

namespace SwedbankPay.Sdk.Models.Requests.Consumers
{
    public class PrepareConsumerRequest
    {
        public string Operation { get; set; } = "prepare-consumer";

        public string ConsumerCountryCode { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Msisdn { get; set; }

        public Address LegalAddress { get; set; }

        public AddressWithAddressee BillingAddress { get; set; }

        public AddressWithAddressee ShippingAddress { get; set; }
    }
}
