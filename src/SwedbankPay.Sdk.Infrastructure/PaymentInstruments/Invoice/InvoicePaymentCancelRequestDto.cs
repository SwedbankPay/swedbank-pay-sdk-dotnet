namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class InvoicePaymentCancelRequestDto
{
    public InvoicePaymentCancelRequestDto(InvoicePaymentCancelRequest payload)
    {
        Transaction = new CancelTransactionDto(payload.Transaction);
    }

    public CancelTransactionDto Transaction { get; }
}