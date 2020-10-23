namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCancellationListDto
    {
        public string Id { get; set; }
        public TransactionDto Transaction { get; set; }
    }
}