namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

/// <summary>
/// Object for storing transactional details cancelling a invoice payment.
/// </summary>
public class InvoicePaymentCancelRequest
{
    /// <summary>
    /// Instantiates a new <see cref="InvoicePaymentCancelRequest"/>
    /// with the provided parameters.
    /// </summary>
    /// <param name="transactionActivity">The <see cref="Operation"/> for this cancel.</param>
    /// <param name="payeeReference">A transactionally unique reference from the merchant system.</param>
    /// <param name="description">A textual description of the cancellation.</param>
    public InvoicePaymentCancelRequest(Operation transactionActivity, string payeeReference, string description)
    {
        Transaction = new CancelTransaction(transactionActivity, payeeReference, description);
    }

    /// <summary>
    /// Details needed to cancel the current invoice payment.
    /// </summary>
    public CancelTransaction Transaction { get; }

}