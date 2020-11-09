using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface ICurrentPaymentResponse
    {
        public Uri PaymentOrder { get; }
        public string MenuElementName { get; }
        public ICurrentPayment Payment { get; }
    }
}