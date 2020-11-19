using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    public class PaymentOrderCaptureRequest
    {
        public PaymentOrderCaptureRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new PaymentOrderCaptureTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }

        /// <summary>
        /// Transactional details about the capture of the current payment order.
        /// </summary>
        public PaymentOrderCaptureTransaction Transaction { get; }
    }
}