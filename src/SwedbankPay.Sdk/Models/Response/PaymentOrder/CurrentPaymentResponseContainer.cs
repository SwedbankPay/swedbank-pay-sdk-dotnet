namespace SwedbankPay.Sdk.Models.Response.PaymentOrder
{
    using SwedbankPay.Sdk.Models.Response.Payment;

    public class CurrentPaymentResponseContainer : PaymentResponseContainer
    {
        public string Id { get; set; }
        public string MenuElementName { get; set; }
    }
}