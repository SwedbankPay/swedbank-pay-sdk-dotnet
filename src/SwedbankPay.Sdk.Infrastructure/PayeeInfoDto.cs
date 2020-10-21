using SwedbankPay.Sdk.Common;
using System;

namespace SwedbankPay.Sdk
{
    public class PayeeInfoDto
    {
        public string Id { get; set; }
        public string OrderReference { get; set; }

        public Guid PayeeId { get; set; }

        public string PayeeName { get; set; }

        public string PayeeReference { get; set; }

        public string ProductCategory { get; set; }

        public string Subsite { get; set; }

        internal PayeeInfo Map()
        {
            return new PayeeInfo(PayeeId, PayeeReference, PayeeName, ProductCategory, Subsite, OrderReference);
        }
    }
}