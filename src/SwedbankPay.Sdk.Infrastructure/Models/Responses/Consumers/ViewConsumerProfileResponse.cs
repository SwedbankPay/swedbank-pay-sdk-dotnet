using SwedbankPay.Sdk.Models.Shared.Consumers;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.Models.Responses.Consumers
{
    public class ViewConsumerProfileResponse
    {
        [JsonPropertyName("id")]
        public string RelativePathId { get; set; }

        [JsonPropertyName("@id")]
        public string AbsolutePathId { get; set; }

        public string ConsumerCountryCode { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Msisdn { get; set; }

        public AddressWithAddressee BillingAddress { get; set; }

        public AddressWithAddressee ShippingAddress { get; set; }
    }
}
