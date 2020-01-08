using SwedbankPay.Sdk.Payments;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderAbortRequestContainer
    {
        public PaymentAbortRequest PaymentOrder { get; } = new PaymentAbortRequest();
    }
}