using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.Models.Shared.Consumers;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.Models.Responses.Consumers
{
    public class IdentifyConsumerResponse
    {
        [JsonPropertyName("id")]
        public string RelativePathId { get; set; }

        [JsonPropertyName("@id")]
        public string AbsolutePathId { get; set; }

        public IdentifyConsumerResponseInput Input { get; set; }

        public string Token { get; set; }

        public string ConsumerProfileRef { get; set; }

        public string Language { get; set; }

        public ValidationFields Validation { get; set; }

        public IEnumerable<Operation> Operations { get; set; }

        public IEnumerable<Action> Actions { get; set; }
    }
    public class IdentifyConsumerResponseInput
    {
        public string Email { get; set; }

        public string Msisdn { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }
    }

    public class ValidationFields
    {
        public IEnumerable<string> ShippingAddressRestrictedToCountryCodes { get; set; }
    }
}
