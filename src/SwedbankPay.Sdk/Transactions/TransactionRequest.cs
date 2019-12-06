namespace SwedbankPay.Sdk.Transactions
{
    using System.Collections.Generic;
    using SwedbankPay.Sdk.PaymentOrders;

    public class TransactionRequest
    {
        public Amount Amount { get; set; }
        public long? VatAmount { get; set; }
        public string Description { get; set; }
        public string PayeeReference { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}
