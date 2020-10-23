using SwedbankPay.Sdk.Common;
using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderPayeeInfoDto
    {
        public string Id { get; set; }
        public string PayeeId { get; set; }
        public string PayeeReference { get; set; }
        public string PayeeName { get; set; }
        public string CorporationId { get; set; }
        public string CorporationName { get; set; }
        public string ProductCategory { get; set; }

        internal PayeeInfo Map()
        {
            return new PayeeInfo(Guid.Parse(PayeeId), PayeeReference, PayeeName, ProductCategory);
        }
    }
}