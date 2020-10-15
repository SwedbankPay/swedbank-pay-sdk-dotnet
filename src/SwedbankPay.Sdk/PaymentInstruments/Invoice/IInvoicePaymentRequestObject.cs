namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentRequestObject
    {
        InvoiceType InvoiceType { get; set; }
    }
}