namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderSaleListDto
    {
        public string Id { get; set; }
        public PaymentOrderTransactionDto Transaction { get; set; }
    }
}