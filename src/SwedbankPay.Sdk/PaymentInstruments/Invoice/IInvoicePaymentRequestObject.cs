namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentRequestObject
    {
        InvoiceType InvoiceType { get; set; }
    }
}