using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using SwedbankPay.Sdk.Consumers;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// If shipIndicator set to 4, then prefil this.
    /// </summary>
    public class PickUpAddress
    {
        public string Name { get; set; }
        public string StreetAddress { get; set; }
        public string CoAddress { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CountryCode CountryCode { get; set; }
    }
}