using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderPayeeInfoDto
    {
        public Uri Id { get; set; }
        public string PayeeId { get; set; }
        public string PayeeReference { get; set; }
        public string PayeeName { get; set; }
        public string CorporationId { get; set; }
        public string CorporationName { get; set; }
        public string ProductCategory { get; set; }

        internal PayeeInfo Map()
        {
            if (string.IsNullOrEmpty(PayeeId))
                return new PayeeInfo(Id);

            return new PayeeInfo(Guid.Parse(PayeeId), PayeeReference, PayeeName, ProductCategory);
        }
    }
}