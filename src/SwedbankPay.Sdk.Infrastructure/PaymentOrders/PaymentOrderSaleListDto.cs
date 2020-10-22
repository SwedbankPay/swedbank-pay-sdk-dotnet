namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderSaleListDto
    {
        public string Id { get; set; }
        public PaymentOrderTransactionListDto Transaction { get; set; }
    }
}