using System;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public interface ICurrentPaymentResponse
    {
        public Uri PaymentOrder { get; }
        public string MenuElementName { get; }
        public ICurrentPaymentResponseObject Payment { get; }
    }
}