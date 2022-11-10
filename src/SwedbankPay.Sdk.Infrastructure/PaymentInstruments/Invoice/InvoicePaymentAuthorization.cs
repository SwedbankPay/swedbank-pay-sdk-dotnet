using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

internal class InvoicePaymentAuthorization : Identifiable, IInvoicePaymentAuthorization
{
    public InvoicePaymentAuthorization(Uri id, InvoicePaymentAuthorizationDto item)
        : base(id)
    {
        Transaction = item.Map();
    }

    public IAuthorizationTransaction Transaction { get; }
}