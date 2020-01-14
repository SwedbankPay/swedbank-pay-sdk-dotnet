using System.Globalization;

namespace SwedbankPay.Sdk.Consumers
{
    public class Address
    {
        public string Addressee { get; set; }
        public string City { get; set; }
        public string CoAddress { get; set; }
        public RegionInfo CountryCode { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
    }
}