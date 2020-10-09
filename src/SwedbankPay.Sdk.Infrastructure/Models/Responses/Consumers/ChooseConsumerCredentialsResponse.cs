using SwedbankPay.Sdk.Models.Shared.Consumers;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.Models.Responses.Consumers
{
    public class ChooseConsumerCredentialsResponse
    {
        [JsonPropertyName("id")]
        public string RelativePathId { get; set; }

        [JsonPropertyName("@id")]
        public string AbsolutePathId { get; set; }

        public ChooseConsumerCredentialsInput Input { get; set; }

        public string Token { get; set; }

        public IEnumerable<Operation> Operations { get; set; }

        public IEnumerable<Action> Actions { get; set; }
    }

    public class ChooseConsumerCredentialsInput
    {
        public string Email { get; set; }

        public string Msisdn { get; set; }

        public NationalIdentifier NationalIdentifier { get; set; }
    }
}
