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
            var payer = new Payer
            {
                Id = Id,
                AccountInfo = AccountInfo,
                BillingAddress = BillingAddress,
                ConsumerProfileRef = ConsumerProfileRef,
                FirstName = FirstName,
                HomePhoneNumber = HomePhoneNumber,
                LastName = LastName,
                ShippingAddress = ShippingAddress,
                WorkPhoneNumber = WorkPhoneNumber
            };
            if (Email != null)
                payer.Email = new EmailAddress(Email);
            if (!String.IsNullOrEmpty(Msisdn))
                payer.Msisdn = new Msisdn(Msisdn);
            if (NationalIdentifier != null)
                payer.NationalIdentifier = new NationalIdentifier(new RegionInfo(NationalIdentifier.CountryCode), NationalIdentifier.SocialSecurityNumber);

            return payer;
        }
    }
}