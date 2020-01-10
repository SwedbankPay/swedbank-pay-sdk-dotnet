using System.Collections.Generic;

using SwedbankPay.Sdk.PaymentOrders;

namespace SwedbankPay.Sdk.Payments.Card
{
    public class CaptureRequest
    {
        public CaptureRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new PaymentOrders.CaptureRequest.CaptureTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }

        public PaymentOrders.CaptureRequest.CaptureTransaction Transaction { get; }

        public class CaptureTransaction
        {
            protected internal CaptureTransaction(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
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
