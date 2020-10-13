using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentAuthorizationListResponse
    {
        List<InvoicePaymentAuthorization> AuthorizationList { get; }
    }
}