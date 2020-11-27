using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// A request for capturing a card payment.
    /// </summary>
    public class CardPaymentCaptureRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="CardPaymentCaptureRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="amount">The <seealso cref="Sdk.Amount"/> to capture.</param>
        /// <param name="vatAmount">The <seealso cref="Sdk.Amount"/> to capture in VAT.</param>
        /// <param name="orderItems">A list of <seealso cref="OrderItem"/> that is part of the payment.</param>
        /// <param name="description">A textual description of the capture.</param>
        /// <param name="payeeReference">A unique payee reference for this capture.</param>
        public CardPaymentCaptureRequest(Amount amount, Amount vatAmount, List<OrderItem> orderItems, string description, string payeeReference)
        {
            Transaction = new CardPaymentCaptureTransaction(amount, vatAmount, orderItems, description, payeeReference);
        }

        /// <summary>
        /// Transactional details about the capture.
        /// </summary>
        public CardPaymentCaptureTransaction Transaction { get; }
    }
}