using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    /// <summary>
    /// Object holding the details needed to capture a invoice payment.
    /// </summary>
    public class InvoicePaymentCaptureRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="InvoicePaymentCaptureRequest"/> with
        /// the provided parameter.
        /// </summary>
        /// <param name="transactionActivity">The API operation to perform.</param>
        /// <param name="amount">The amount to capture in this transaction.</param>
        /// <param name="vatAmount">The VAT amount to capture in this transaction.</param>
        /// <param name="orderItems">List of <seealso cref="IOrderItem"/> to be captured in this transaction.</param>
        /// <param name="description">A textual description of the capture.</param>
        /// <param name="payeeReference">Transactionally unique reference from the merchant system.</param>
        public InvoicePaymentCaptureRequest(Operation transactionActivity,
                                              Amount amount,
                                              Amount vatAmount,
                                              IEnumerable<IOrderItem> orderItems,
                                              string description,
                                              string payeeReference)
        {
            Transaction = new CaptureTransaction(transactionActivity, amount, vatAmount, orderItems, description, payeeReference);
        }

        /// <summary>
        /// Details needed to capture the current payment.
        /// </summary>
        public ICaptureTransaction Transaction { get; }
    }
}