namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentAuthorizationRequestDto
    {
        public InvoicePaymentAuthorizationRequestDto(InvoicePaymentAuthorizationRequest payload)
        {
            Transaction = new InvoicePaymentAuthorizationTransactionDto(payload.Transaction);
        }

        public InvoicePaymentAuthorizationTransactionDto Transaction { get; }
    }
}