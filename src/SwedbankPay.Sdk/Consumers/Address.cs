using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SwedbankPay.Sdk.Consumers
{
    public class Address
    {
        public string Addressee { get; set; }
        public string CoAddress { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode CountryCode { get; set; }

    }
}
