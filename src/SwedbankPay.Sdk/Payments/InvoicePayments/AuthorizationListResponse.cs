using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public class AuthorizationListResponse : IdLink
    {
        public AuthorizationListResponse(Uri id, List<Authorization> authorizationList)
        {
            Id = id;
            AuthorizationList = authorizationList;
        }


        public List<Authorization> AuthorizationList { get; }
    }
}