namespace SwedbankPay.Sdk.PaymentInstruments.Trustly;

/// <summary>
/// API object for reversing a Trustly payment.
/// </summary>
public class TrustlyPaymentReversalRequest
{
    /// <summary>
    /// Instantiates a <see cref="TrustlyPaymentReversalRequest"/> with the provided parameters.
    /// </summary>
    /// <param name="operation">The API operation to perform.</param>
    /// <param name="amount">The <seealso cref="Amount"/> to be reversed.</param>
    /// <param name="description">A textual description of the reversal.</param>
    /// <param name="payeeReference">A transactionally unique payee reference from the merchant system.</param>
    /// <param name="receiptReference">The receiptReference is a reference from the merchant system.
    /// This reference is used as an invoice/receipt number.</param>
    /// <param name="vatAmount">The Value Added Taxes to be reversed.</param>
    public TrustlyPaymentReversalRequest(Operation operation, Amount amount, Amount vatAmount, string payeeReference, string receiptReference, string description)
    {
        Transaction = new TrustlyReversalTransaction(operation, amount, vatAmount, payeeReference, receiptReference, description);
    }

    /// <summary>
    /// Data to reverse a Trustly payment.
    /// </summary>
    public TrustlyReversalTransaction Transaction { get; }
}
