namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderReversalListDto
    {
        public string Id { get; set; }
        public PaymentOrderTransactionDto Transaction { get; set; }
    }
}