namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentCaptureRequest
    {
        ICaptureTransaction Transaction { get; }
    }
}