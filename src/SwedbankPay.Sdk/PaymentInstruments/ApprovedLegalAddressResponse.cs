using System;

namespace SwedbankPay.Sdk.Payments
{

    public class ApprovedLegalAddressResponse
    {
        public ApprovedLegalAddressResponse(Uri payment, LegalAddress approvedLegalAddress)
        {
            Payment = payment;
            ApprovedLegalAddress = approvedLegalAddress;
        }

        public Uri Payment { get; }
        public LegalAddress ApprovedLegalAddress { get; }

        public class LegalAddress
        {
            protected internal LegalAddress(Uri id, string addressee, string coAddress, string streetAddress, string zipCode, string city, string countryCode)
            {
                Id = id;
                Addressee = addressee;
                CoAddress = coAddress;
                StreetAddress = streetAddress;
                ZipCode = zipCode;
                City = city;
                CountryCode = countryCode;
            }

            public Uri Id { get; }
            public string Addressee { get; }
            public string CoAddress { get; }
            public string StreetAddress { get; }
            public string ZipCode { get; }
            public string City { get; }
            public string CountryCode { get; }

        }
    }
}