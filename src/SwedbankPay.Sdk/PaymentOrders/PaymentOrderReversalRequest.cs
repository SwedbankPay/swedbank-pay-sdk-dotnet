using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentOrders
{
    /// <summary>
    /// API request to reverse captured funds.
    /// </summary>
    public class PaymentOrderReversalRequest
    {
        /// <summary>
        /// Instantaites a <see cref="PaymentOrderReversalRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The amount to refund to the payer.</param>
        /// <param name="vatAmount">The amount of VAT to refund.</param>
        /// <param name="orderItems">Order items being refunded for.</param>
        /// <param name="description">Textual description of the reversal.</param>
        /// <param name="payeeReference">Unique ID set by the merchant for this transaction.</param>
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