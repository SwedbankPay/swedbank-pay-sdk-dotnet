using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentAuthorizationListResponse
    {
        List<IInvoicePaymentAuthorization> AuthorizationList { get; }
    }
}