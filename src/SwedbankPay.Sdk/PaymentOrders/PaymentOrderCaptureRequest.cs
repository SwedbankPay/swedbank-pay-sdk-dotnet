using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// API request object for capturing funds for a payment order.
    /// </summary>
    public class PaymentOrderCaptureRequest
    {
        /// <summary>
        /// Instantiates a <see cref="PaymentOrderCaptureRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The amount of funds to capture.</param>
        /// <param name="vatAmount">The amount of funds to capture as value added taxes.</param>
        /// <param name="orderItems"><seealso cref="OrderItem"/>s involved in the capture.</param>
        /// <param name="description">A textual description of the capture.</param>
        /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
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