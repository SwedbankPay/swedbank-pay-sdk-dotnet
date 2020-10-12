using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class InvoicePaymentAuthorizationListResponse : IdLink, IInvoicePaymentAuthorizationListResponse1
    {
        public InvoicePaymentAuthorizationListResponse(Uri id, List<IInvoicePaymentAuthorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<IInvoicePaymentAuthorization> AuthorizationList { get; }
    }
}