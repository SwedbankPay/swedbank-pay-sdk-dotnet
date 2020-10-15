using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentAuthorizationResponse
    {
        IInvoicePaymentAuthorization Authorization { get; }
        Uri Payment { get; }
    }
}