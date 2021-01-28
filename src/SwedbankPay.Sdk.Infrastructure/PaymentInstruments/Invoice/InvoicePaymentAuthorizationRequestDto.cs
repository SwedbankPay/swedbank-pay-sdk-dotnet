namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentAuthorizationRequestDto
    {
        public InvoicePaymentAuthorizationRequestDto(InvoicePaymentAuthorizationRequest payload)
        {
            Transaction = new InvoicePaymentAuthorizationTransactionDto(payload.Payment);
            Invoice = new InvoiceDetailsDto(payload.Invoice);
        }

        public InvoicePaymentAuthorizationTransactionDto Transaction { get; set; }
        public InvoiceDetailsDto Invoice { get; set; }
    }
}