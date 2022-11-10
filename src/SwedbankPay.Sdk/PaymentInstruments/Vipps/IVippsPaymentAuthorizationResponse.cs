using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps;

/// <summary>
/// Resource for getting the authorization on a Vipps payment.
/// </summary>
public interface IVippsPaymentAuthorizationResponse
{
    /// <summary>
    /// A unique <seealso cref="Uri"/> to access this authorization.
    /// </summary>
    Uri Payment { get; }

    /// <summary>
    /// Transactional details about the authroization.
    /// </summary>
    IVippsPaymentAuthorization Authorization { get; }
}