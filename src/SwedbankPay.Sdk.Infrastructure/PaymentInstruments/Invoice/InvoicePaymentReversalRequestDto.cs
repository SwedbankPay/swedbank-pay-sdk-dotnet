namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentReversalRequestDto
    {
        public InvoicePaymentReversalRequestDto(InvoicePaymentReversalRequest payload)
        {
            Transaction = new ReversalTransactionDto(payload.Transaction);
        }

        public ReversalTransactionDto Transaction { get; }
    }
}