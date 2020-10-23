namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCaptureListDto
    {
        public string Id { get; set; }
        public TransactionDto Transaction { get; set; }
    }
}