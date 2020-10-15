using SwedbankPay.Sdk.Common;
using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentAuthorizationListResponse : IdLink
    {
        public InvoicePaymentAuthorizationListResponse(Uri id, List<IInvoicePaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<IInvoicePaymentAuthorization> AuthorizationList { get; }
    }
}