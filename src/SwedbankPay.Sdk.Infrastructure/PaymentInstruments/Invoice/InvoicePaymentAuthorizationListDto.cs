using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments
{
    public class InvoicePaymentAuthorizationListDto : IInvoicePaymentAuthorizationListResponse
    {
        public List<InvoicePaymentAuthorization> AuthorizationList => throw new NotImplementedException();

        public IInvoicePaymentAuthorizationListResponse Map() => throw new NotImplementedException();
    }
}