namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentReversalRequest
    {
        public InvoicePaymentReversalRequest(Amount amount, Amount vatAmount, string description, string payeeReference,string receiptReference)
        {
            Transaction = new ReversalTransaction(amount, vatAmount, description, payeeReference, receiptReference);
        }

        /// <summary>
        /// Details about the invoice being reversed.
        /// </summary>
        public IReversalTransaction Transaction { get; }
    }
}