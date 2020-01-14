using System.Collections.Generic;
using System.Globalization;

using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class ConsumersRequestContainerBuilder
    {
        private EmailAddress email;
        private CultureInfo language;
        private Msisdn msisdn;
        private NationalIdentifier nationalIdentifier;
        private Operation operation;
        private IEnumerable<RegionInfo> shippingAddressRestrictedToCountryCodes;


        public ConsumersRequest Build()
        {
            return new ConsumersRequest(this.language, this.shippingAddressRestrictedToCountryCodes, this.operation, this.msisdn,
                                        this.email, this.nationalIdentifier);
        }


        public ConsumersRequestContainerBuilder WithEmptyShippingAddressCountryCodes()
        {
            this.shippingAddressRestrictedToCountryCodes = null;
            return this;
        }


        public ConsumersRequestContainerBuilder WithTestValues()
        {
            this.operation = Operation.Initiate;
            this.language = new CultureInfo("sv-SE");
            this.shippingAddressRestrictedToCountryCodes = new List<RegionInfo>
                { new RegionInfo("SE"), new RegionInfo("NO"), new RegionInfo("DK") };
            return this;
        }
    }
}