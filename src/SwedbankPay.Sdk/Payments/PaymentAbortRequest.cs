namespace SwedbankPay.Sdk.Payments
{
    public partial class PaymentAbortRequest
    {
        public PaymentAbortRequestObject Payment { get; } = new PaymentAbortRequestObject();
    }
}