using System;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay;

/// <summary>
/// Object holding a reference to a authorization resource.
/// </summary>
public interface IMobilePayPaymentAuthorizationResponse
{
    /// <summary>
    /// The currently available information about the authorization of the payment.
    /// </summary>
    IMobilePayPaymentAuthorization Authorization { get; }

    /// <summary>
    /// The <seealso cref="Uri"/> to get the details about the currently available authorization.
    /// </summary>
    Uri Payment { get; }
}