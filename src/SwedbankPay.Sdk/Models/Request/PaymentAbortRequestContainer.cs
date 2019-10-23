namespace SwedbankPay.Sdk.Models.Request
{
    public class PaymentAbortRequestContainer
    {
        public PaymentAbortRequest PaymentOrder { get; set; } = new PaymentAbortRequest();
    }
}