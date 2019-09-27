namespace SwedbankPay.Client.Models.Request
{
    public class PaymentAbortRequestContainer
    {
        public PaymentAbortRequest PaymentOrder { get; set; } = new PaymentAbortRequest();
    }
}