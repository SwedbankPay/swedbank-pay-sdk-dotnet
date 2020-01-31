using System.Collections.Generic;
using System.Globalization;

using SwedbankPay.Sdk.Consumers;
using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Tests.TestBuilders
{
    public class ConsumersRequestContainerBuilder
    {
        private Language language;
        private NationalIdentifier nationalIdentifier;
        private Operation operation;
        private IEnumerable<RegionInfo> shippingAddressRestrictedToCountryCodes;


        public ConsumersRequest Build()
        {
            return new ConsumersRequest(language, shippingAddressRestrictedToCountryCodes, operation, null,
                                        null, nationalIdentifier);
        }


        public ConsumersRequestContainerBuilder WithEmptyShippingAddressCountryCodes()
        {
            shippingAddressRestrictedToCountryCodes = null;
            return this;
        }


        public ConsumersRequestContainerBuilder WithNationalIdentifier()
        {
            nationalIdentifier = new NationalIdentifier(new RegionInfo("sv-SE"), "19891010292" );
            return this;
        }


        public ConsumersRequestContainerBuilder WithTestValues()
        {
            operation = Operation.Initiate;
            language = new Language("sv-SE"); 
            shippingAddressRestrictedToCountryCodes = new List<RegionInfo>
                { new RegionInfo("SE"), new RegionInfo("NO"), new RegionInfo("DK") };
            return this;
        }
    }
}