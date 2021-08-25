namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
	internal class AddressDto
    {
        public AddressDto() { }
        
        public AddressDto(IAddress address)
        {
            City = address.City;
            CoAddress = address.CoAddress;
            CountryCode = address.CountryCode;
            StreetAddress = address.StreetAddress;
        }

        public AddressDto(Address address) : this(address as IAddress)
        {
            Email = address.Email.ToString();
            FirstName = address.FirstName;
            LastName = address.LastName;
            Msisdn = address.Msisdn.ToString();
            ZipCode = address.ZipCode;
        }

        public AddressDto(PickUpAddress address): this(address as IAddress)
        {
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