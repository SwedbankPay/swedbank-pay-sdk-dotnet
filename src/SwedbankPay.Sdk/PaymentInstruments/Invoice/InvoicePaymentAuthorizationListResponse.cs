using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentAuthorizationListResponse : IdLink, IInvoicePaymentAuthorizationListResponse
    {
        public InvoicePaymentAuthorizationListResponse(Uri id, List<IInvoicePaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }

        /// <summary>
        /// A list of available authorizations on the current invoice.
        /// </summary>
        public List<IInvoicePaymentAuthorization> AuthorizationList { get; }
    }
}