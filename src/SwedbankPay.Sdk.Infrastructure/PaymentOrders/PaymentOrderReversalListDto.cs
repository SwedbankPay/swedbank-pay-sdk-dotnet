namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderReversalListDto
    {
        public string Id { get; set; }
        public PaymentOrderTransactionListDto Transaction { get; set; }
    }
}