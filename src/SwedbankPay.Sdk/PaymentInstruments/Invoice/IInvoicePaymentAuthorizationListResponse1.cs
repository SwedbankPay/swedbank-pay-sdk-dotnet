using System.Collections.Generic;

namespace SwedbankPay.Sdk.Payments.InvoicePayments
{
    public interface IInvoicePaymentAuthorizationListResponse1
    {
        List<IInvoicePaymentAuthorization> AuthorizationList { get; }
    }
}