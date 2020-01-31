using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class ReversalRequest
    {
        public ReversalRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new ReversalTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }


        public ReversalTransaction Transaction { get; }
    }
}