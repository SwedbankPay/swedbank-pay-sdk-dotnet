using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Invoice;

/// <summary>
/// Wrapper for a invoice payment authorization.
/// </summary>
public interface IInvoicePaymentAuthorizationResponse
{
    /// <summary>
    /// A <seealso cref="Uri"/> to this authorization response.
    /// </summary>
    Uri Payment { get; }

    /// <summary>
    /// Transactional details about this authorization.
    /// </summary>
    IInvoicePaymentAuthorization Authorization { get; }
}