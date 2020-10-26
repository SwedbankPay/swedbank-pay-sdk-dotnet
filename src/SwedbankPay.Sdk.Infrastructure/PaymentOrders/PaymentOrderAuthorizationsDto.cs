using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderAuthorizationsDto
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Updated { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public string Number { get; set; }
        public int Amount { get; set; }
        public int VatAmount { get; set; }
        public string Description { get; set; }
        public string PayeeReference { get; set; }

        internal IPaymentAuthorizationResponse Map()
        {
            return new PaymentAuthorizationResponse(this);
        }
    }
}