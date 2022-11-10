using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish;

/// <summary>
/// Describes a Swish payment response using the Sale operation.
/// </summary>
public interface ISwishPaymentSale : IIdentifiable
{
    /// <summary>
    /// Shows when the payment was created.
    /// </summary>
    DateTime Created { get; }

    /// <summary>
    /// When the current payment was last updated.
    /// </summary>
    DateTime Updated { get; }

    /// <summary>
    /// Only available in M-Commerece payment flows.
    /// Reference to a Swish payment.
    /// </summary>
    string PaymentRequestToken { get; }

    /// <summary>
    /// Information about the current transaction of the payment.
    /// </summary>
    ITransaction Transaction { get; }
}