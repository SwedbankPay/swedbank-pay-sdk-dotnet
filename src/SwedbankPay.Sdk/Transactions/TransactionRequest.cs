using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Transactions
{
    public class TransactionRequest
    {
        public TransactionRequest(Amount amount, string description, List<OrderItem> orderItems, string payeeReference, long? vatAmount)
        {
            Amount = amount;
            Description = description;
            OrderItems = orderItems;
            PayeeReference = payeeReference;
            VatAmount = vatAmount;
        }

        public Amount Amount { get; }
        public string Description { get; }
        public List<OrderItem> OrderItems { get; }
        public string PayeeReference { get; }
        public long? VatAmount { get; }
    }
}