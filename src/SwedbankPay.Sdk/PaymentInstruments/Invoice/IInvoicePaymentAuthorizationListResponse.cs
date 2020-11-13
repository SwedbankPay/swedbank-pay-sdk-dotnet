using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice
{
    public interface IInvoicePaymentAuthorizationListResponse
    {
        /// <summary>
        /// A list of authorizations done on this invoice payment.
        /// </summary>
        List<IInvoicePaymentAuthorization> AuthorizationList { get; }
    }
}