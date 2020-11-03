namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class PaymentAbortRequest
    {
        public PaymentAbortRequestObject Payment { get; set; } = new PaymentAbortRequestObject();
    }
}