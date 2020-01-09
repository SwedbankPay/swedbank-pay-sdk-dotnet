using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders.OperationRequests
{
    public class ReversalRequest
    {
        public ReversalRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new ReversalTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }

        public ReversalTransaction Transaction { get; }

        public class ReversalTransaction
        {
            protected internal ReversalTransaction(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
            {
                Amount = amount;
                VatAmount = vatAmount;
                OrderItems = orderItems;
                Description = description;
                PayeeReference = payeeReference;
            }

            public Amount Amount { get; }
            public Amount VatAmount { get; }
            public List<OrderItem> OrderItems { get; }
            public string Description { get; }
            public string PayeeReference { get; }
        }
    }
}
