namespace SwedbankPay.Sdk.PaymentInstruments
{
    public class PaymentAbortRequest
    {
        public PaymentAbortRequestData Payment { get; set; } = new PaymentAbortRequestData();
    }
}