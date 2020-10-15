using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentAuthorizationResponse : IInvoicePaymentAuthorizationResponse
    {
        public InvoicePaymentAuthorizationResponse(Uri payment, IInvoicePaymentAuthorization authorization)
        {
            Payment = payment;
            Authorization = authorization;
        }


        public IInvoicePaymentAuthorization Authorization { get; }
        public Uri Payment { get; }
    }
}