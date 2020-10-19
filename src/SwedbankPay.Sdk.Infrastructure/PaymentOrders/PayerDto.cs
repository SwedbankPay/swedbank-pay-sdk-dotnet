using SwedbankPay.Sdk.Common;
using System;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PayerDto
    {
        public Uri Id { get; set; }
        public AccountInfo AccountInfo { get; set; }
        public Address BillingAddress { get; set; }
        public string ConsumerProfileRef { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string HomePhoneNumber { get; set; }
        public string LastName { get; set; }
        public string Msisdn { get; set; }
        public NationalIdentifierDto NationalIdentifier { get; set; }
        public Address ShippingAddress { get; set; }
        public string WorkPhoneNumber { get; set; }

        internal Payer Map()
        {
            return new Payer
            {
                Id = Id,
                AccountInfo = AccountInfo,
                BillingAddress = BillingAddress,
                ConsumerProfileRef = ConsumerProfileRef,
                Email = new EmailAddress(Email),
                FirstName = FirstName,
                HomePhoneNumber = HomePhoneNumber,
                LastName = LastName,
                Msisdn = new Msisdn(Msisdn),
                NationalIdentifier = new NationalIdentifier(new RegionInfo(NationalIdentifier.CountryCode), NationalIdentifier.SocialSecurityNumber),
                ShippingAddress = ShippingAddress,
                WorkPhoneNumber = WorkPhoneNumber
            };
        }
    }
}