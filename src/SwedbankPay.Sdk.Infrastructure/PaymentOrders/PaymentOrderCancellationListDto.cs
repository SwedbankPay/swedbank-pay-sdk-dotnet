namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCancellationListDto
    {
        public string Id { get; set; }
        public PaymentOrderTransactionListDto Transaction { get; set; }
    }
}