﻿using SwedbankPay.Sdk.Consumers;
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
        private IEnumerable<RegionInfo> shippingAddressRestrictedToCountryCodes;


        public ConsumerRequest Build()
        {
            var req = new ConsumerRequest(this.language)
            {
                Operation = operation,
                NationalIdentifier = nationalIdentifier
            };

            if(shippingAddressRestrictedToCountryCodes != null)
            {
                req.ShippingAddressRestrictedToCountryCodes.AddRange(this.shippingAddressRestrictedToCountryCodes);
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
            this.nationalIdentifier = new NationalIdentifier(new RegionInfo("sv-SE"), "19891010292");
            return this;
        }


        public ConsumerRequestContainerBuilder WithTestValues()
        {
            this.operation = Operation.Initiate;
            this.language = new Language("sv-SE");
            this.shippingAddressRestrictedToCountryCodes = new List<RegionInfo>
                { new RegionInfo("SE"), new RegionInfo("NO"), new RegionInfo("DK") };
            return this;
        }
    }
}