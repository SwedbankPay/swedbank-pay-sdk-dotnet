using System.Globalization;

namespace SwedbankPay.Sdk.Common
{
    public class Address
    {
        public string City { get; set; }
        public string CoAddress { get; set; }
        public RegionInfo CountryCode { get; set; }
        public EmailAddress Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Msisdn Msisdn { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
    }
}