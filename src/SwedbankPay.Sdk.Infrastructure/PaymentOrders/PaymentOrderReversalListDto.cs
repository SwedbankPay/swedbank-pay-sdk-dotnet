namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderReversalListDto
    {
        public string Id { get; set; }
        public TransactionDto Transaction { get; set; }
    }
}