using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public class InvoicePaymentAuthorizationListDto : IInvoicePaymentAuthorizationListResponse
    {
        public List<InvoicePaymentAuthorization> AuthorizationList => throw new NotImplementedException();

        public IInvoicePaymentAuthorizationListResponse Map() => throw new NotImplementedException();
    }
}