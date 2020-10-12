namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentRequest
    {
        IInvoicePaymentRequestObject Invoice { get; }
        IPaymentRequestObject Payment { get; }
    }
}