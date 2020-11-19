using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderReversalRequest
    {
        public PaymentOrderReversalRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new PaymentOrderReversalTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }

        /// <summary>
        /// Transactional details about what is being reversed.
        /// </summary>
        public PaymentOrderReversalTransaction Transaction { get; }
    }
}