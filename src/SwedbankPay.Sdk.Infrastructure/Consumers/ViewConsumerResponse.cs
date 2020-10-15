using SwedbankPay.Sdk.Common;
using SwedbankPay.Sdk.Models.Shared.Consumers;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SwedbankPay.Sdk.Models.Responses.Consumers
{
    public class ViewConsumerResponse
    {
        [JsonPropertyName("id")]
        public string RelativePath { get; set; }

        [JsonPropertyName("@id")]
        public Uri AbsolutePath { get; set; }

        public Profile Profile { get; set; }

        public string Token { get; set; }

        public string ConsumerProfileRef { get; set; }

        public IEnumerable<Operation> Operations { get; set; }

        public IEnumerable<Shared.Consumers.Action> Actions { get; set; }
    }
}
