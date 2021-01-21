using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class ConsumerRequestContainerBuilder
    {
        private Language language;
        private NationalIdentifier nationalIdentifier;
        private Operation operation;
        private IEnumerable<CountryCode> shippingAddressRestrictedToCountryCodes;


        public ConsumerRequest Build()
        {
            var req = new ConsumerRequest(this.language)
            {
                Operation = operation,
                NationalIdentifier = nationalIdentifier
            };

            if(shippingAddressRestrictedToCountryCodes != null)
            {
                foreach (var countryCode in shippingAddressRestrictedToCountryCodes)
                {
                    req.ShippingAddressRestrictedToCountryCodes.Add(countryCode);
                }
            }

            return req;
        }


        public ConsumerRequestContainerBuilder WithEmptyShippingAddressCountryCodes()
        {
            this.shippingAddressRestrictedToCountryCodes = null;
            return this;
        }


        public ConsumerRequestContainerBuilder WithNationalIdentifier()
        {
            this.nationalIdentifier = new NationalIdentifier(new CountryCode("sv-SE"), "19891010292");
            return this;
        }


        public ConsumerRequestContainerBuilder WithTestValues()
        {
            this.operation = Operation.Initiate;
            this.language = new Language("sv-SE");
            this.shippingAddressRestrictedToCountryCodes = new List<CountryCode>
                { new CountryCode("SE"), new CountryCode("NO"), new CountryCode("DK") };
            return this;
        }
    }
}