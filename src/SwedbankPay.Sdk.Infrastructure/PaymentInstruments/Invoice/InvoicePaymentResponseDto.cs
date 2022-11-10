namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class InvoicePaymentResponseDto
{
    public OperationListDto Operations { get; set; }

    public InvoicePaymentDto Payment { get; set; }
}