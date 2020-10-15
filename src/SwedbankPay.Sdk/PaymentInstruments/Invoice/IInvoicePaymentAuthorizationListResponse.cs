using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentAuthorizationListResponse
    {
        List<InvoicePaymentAuthorization> AuthorizationList { get; }
    }
}