using System;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentAuthorizationResponse
    {
        public InvoicePaymentAuthorizationResponse(Uri payment, InvoicePaymentAuthorization authorization)
        {
            Payment = payment;
            Authorization = authorization;
        }


        public InvoicePaymentAuthorization Authorization { get; }

        public Uri Payment { get; }
    }
}