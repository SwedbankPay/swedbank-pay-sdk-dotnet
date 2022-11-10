namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

/// <summary>
/// Object containing details needed for reversing a invoice payment.
/// </summary>
public class InvoicePaymentReversalRequest
{
    /// <summary>
    /// Instantiates a new <see cref="InvoicePaymentReversalRequest"/> with the provided parameters.
    /// </summary>
    /// <param name="amount">The <seealso cref="Amount"/> to return to the payer.</param>
    /// <param name="vatAmount">The <seealso cref="Amount"/> to return from the VAT amount.</param>
    /// <param name="description">A textual description of the reversal.</param>
    /// <param name="payeeReference">The payeeReference is the receipt/invoice number if receiptReference is not defined,
    /// which is a unique reference with max 50 characters set by the merchant system.
    /// This must be unique for each operation and must follow the regex pattern [\w-]*.</param>
    /// <param name="receiptReference">The receiptReference is a reference from the merchant system.
    /// This reference is used as an invoice/receipt number.</param>
    public InvoicePaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference,string receiptReference)
    {
        Transaction = new ReversalTransaction(amount, vatAmount, description, payeeReference, receiptReference);
    }

    /// <summary>
    /// Details about the invoice being reversed.
    /// </summary>
    public IReversalTransaction Transaction { get; }
}