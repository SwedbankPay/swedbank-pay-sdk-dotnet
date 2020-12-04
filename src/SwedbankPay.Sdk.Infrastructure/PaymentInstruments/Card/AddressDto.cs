using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class AddressDto
    {
        public AddressDto() { }

        public AddressDto(Address address)
        {
            City = address.City;
            CoAddress = address.CoAddress;
            CountryCode = address.CountryCode.Name;
            Email = address.Email.ToString();
            FirstName = address.FirstName;
            LastName = address.LastName;
            Msisdn = address.Msisdn.ToString();
            StreetAddress = address.StreetAddress;
            ZipCode = address.ZipCode;
        }

        public AddressDto(PickUpAddress address)
        {
            City = address.City;
            CoAddress = address.CoAddress;
            CountryCode = address.CountryCode.Name;
            StreetAddress = address.StreetAddress;
            ZipCode = address.ZipCode;
            Name = address.Name;
        }

        public string City { get; set; }

        public string CoAddress { get; set; }

        public string CountryCode { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Msisdn { get; set; }

        public string StreetAddress { get; set; }

        public string ZipCode { get; set; }

        public string Name { get; set; }
    }
}