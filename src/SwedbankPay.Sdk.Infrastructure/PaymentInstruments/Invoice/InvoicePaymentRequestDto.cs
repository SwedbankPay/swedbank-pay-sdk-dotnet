namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class InvoicePaymentRequestDto
{
    public InvoicePaymentRequestDto(InvoicePaymentRequest paymentRequest)
    {
        Payment = new PaymentRequestDetailsDto(paymentRequest.Payment);
        Invoice = new InvoiceDetailsDto(paymentRequest.Invoice);
    }

    public PaymentRequestDetailsDto Payment { get; }

    public InvoiceDetailsDto Invoice { get; }
}