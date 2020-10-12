using System;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentAuthorizationResponse
    {
        IInvoicePaymentAuthorization Authorization { get; }
        Uri Payment { get; }
    }
}