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

        /// <summary>
        /// Details about the payments current authorization if available.
        /// </summary>
        public IInvoicePaymentAuthorization Authorization { get; }

        /// <summary>
        /// A <seealso cref="Uri"/> to the authorization if available.
        /// </summary>
        public Uri Payment { get; }
    }
}