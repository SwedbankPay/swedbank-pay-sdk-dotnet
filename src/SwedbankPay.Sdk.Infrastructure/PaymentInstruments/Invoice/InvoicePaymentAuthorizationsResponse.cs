using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentAuthorizationsResponse
    {
        public InvoicePaymentAuthorizationsResponse(Uri payment, IInvoicePaymentAuthorizationListResponse authorizationList)
        {
            Payment = payment;
            AuthorizationList = authorizationList;
        }

        /// <summary>
        /// The current list of authorizations for this invoice if available.
        /// </summary>
        public IInvoicePaymentAuthorizationListResponse AuthorizationList { get; }

        /// <summary>
        /// A <seealso cref="Uri"/> to get authorization details about the current payment.
        /// </summary>
        public Uri Payment { get; }
    }
}