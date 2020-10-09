using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentAuthorizationListResponse : IdLink
    {
        public InvoicePaymentAuthorizationListResponse(Uri id, List<InvoicePaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<InvoicePaymentAuthorization> AuthorizationList { get; }
    }
}