using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionRequest
    {
        public Amount Amount { get; set; }
        public string Description { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string PayeeReference { get; set; }
        public long? VatAmount { get; set; }
    }
}