namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePayment
    {
        InvoiceType InvoiceType { get; set; }
    }
}