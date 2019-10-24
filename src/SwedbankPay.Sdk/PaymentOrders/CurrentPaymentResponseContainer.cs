namespace SwedbankPay.Sdk.PaymentOrders
{
    using SwedbankPay.Sdk.Payments;

    public class CurrentPaymentResponseContainer : PaymentResponseContainer
    {
        public string Id { get; set; }
        public string MenuElementName { get; set; }
    }
}