using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

/// <summary>
/// Wrapper for a list of invoice authorizations.
/// </summary>
public interface IInvoicePaymentAuthorizationListResponse
{
    /// <summary>
    /// A list of authorizations done on this invoice payment.
    /// </summary>
    IList<IInvoicePaymentAuthorization> AuthorizationList { get; }
}