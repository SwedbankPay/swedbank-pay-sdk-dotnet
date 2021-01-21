using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentAuthorizationList : Identifiable, IInvoicePaymentAuthorizationList
    {
        public InvoicePaymentAuthorizationList(Uri id, IList<IInvoicePaymentAuthorization> authorizationList)
            : base(id)
        {
            AuthorizationList = authorizationList;
        }

        /// <summary>
        /// A list of available authorizations on the current invoice.
        /// </summary>
        public IList<IInvoicePaymentAuthorization> AuthorizationList { get; }
    }
}