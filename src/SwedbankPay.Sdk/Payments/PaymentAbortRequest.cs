namespace SwedbankPay.Sdk.Payments
{
    public class PaymentAbortRequest
    {
        public PaymentAbortRequestObject Payment { get; } = new PaymentAbortRequestObject();
    }
}