using SwedbankPay.Sdk.Common;
using System;

namespace SwedbankPay.Sdk
{
    public class PayeeInfoDto
    {
        public string OrderReference { get; }

        public Guid PayeeId { get; }

        public string PayeeName { get; }

        public string PayeeReference { get; }

        public string ProductCategory { get; }

        public string Subsite { get; }

        internal PayeeInfo Map()
        {
            return new PayeeInfo(PayeeId, PayeeReference, PayeeName, ProductCategory, Subsite, OrderReference);
        }
    }
}