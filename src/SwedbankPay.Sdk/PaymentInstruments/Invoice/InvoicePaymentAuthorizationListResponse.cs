using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
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