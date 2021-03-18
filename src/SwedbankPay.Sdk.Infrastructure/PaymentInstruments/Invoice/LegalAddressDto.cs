using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class LegalAddressDto
    {
        public string Id { get; set; }
        public string Addressee { get; set; }
        public string CoAddress { get; set; }
        public string StreetAddress { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }

        internal LegalAddress Map()
        {
            var uri = new Uri(Id, UriKind.RelativeOrAbsolute);
            return new LegalAddress(uri,
                                    Addressee,
                                    CoAddress,
                                    StreetAddress,
                                    ZipCode,
                                    City,
                                    CountryCode);
        }
    }
}