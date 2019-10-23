using SwedbankPay.Client.Models.Response.Payment;

namespace SwedbankPay.Client.Models.Response.PaymentOrder
{
    public class CurrentPaymentResponseContainer : PaymentResponseContainer
    {
        public string Id { get; set; }
        public string MenuElementName { get; set; }
    }
}