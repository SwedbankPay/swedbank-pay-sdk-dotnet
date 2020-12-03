using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    internal class InvoicePaymentAuthorization : Identifiable, IInvoicePaymentAuthorization
    {
        public InvoicePaymentAuthorization(Uri id, InvoicePaymentAuthorizationDto item)
        {
            Id = id;
            Transaction = item.Map();
        }

        public IAuthorizationTransaction Transaction { get; }
    }
}