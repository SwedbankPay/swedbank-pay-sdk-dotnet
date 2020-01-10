using System.Collections.Generic;
using System.Globalization;

using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class ConsumersRequestContainerBuilder
    {
        private CountryCode consumerCountryCode;
        private EmailAddress email;
        private Msisdn msisdn;
        private NationalIdentifier nationalIdentifier;
        private Operation operation;
        private Language language;
        private ICollection<string> shippingAddressRestrictedToCountryCodes;


        public ConsumersRequest Build()
        {
            return new ConsumersRequest(this.language, shippingAddressRestrictedToCountryCodes: this.shippingAddressRestrictedToCountryCodes);
        }


        public ConsumersRequestContainerBuilder WithTestValues()
        {
            this.operation = Operation.Initiate;
            this.language = new Language(new CultureInfo("sv-SE"));
            this.shippingAddressRestrictedToCountryCodes = new List<string>{"SE", "NO", "DK"};
            return this;
        }

        public ConsumersRequestContainerBuilder WithEmptyShippingAddressCountryCodes()
        {
            this.shippingAddressRestrictedToCountryCodes = null;
            return this;
        }

    }
}