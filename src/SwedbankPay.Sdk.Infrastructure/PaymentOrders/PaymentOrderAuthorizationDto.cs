using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    internal class PaymentOrderAuthorizationDto
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public long Number { get; set; }
        public long Amount { get; set; }
        public long VatAmount { get; set; }
        public string Description { get; set; }
        public string PayeeReference { get; set; }

        internal IPaymentAuthorizationResponse Map()
        {
            return new PaymentAuthorizationResponse(this);
        }
    }
}