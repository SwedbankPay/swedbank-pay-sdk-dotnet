using System;

namespace SwedbankPay.Sdk.PaymentInstruments;

/// <summary>
/// Holds details a bout a cancelled payments.
/// </summary>
public class CancellationResponse : ICancellationResponse
{
    /// <summary>
    /// Instantiates a new response about a cancelled payment.
    /// </summary>
    /// <param name="payment">The <seealso cref="Uri"/> of the payment.</param>
    /// <param name="cancellation">Details about the transaction.</param>
    public CancellationResponse(Uri payment, ITransactionResponse cancellation)
    {
        Payment = payment;
        Cancellation = cancellation;
    }

    /// <summary>
    /// A unique <seealso cref="Uri"/> to access this resource.
    /// </summary>
    public Uri Payment { get; }

    /// <summary>
    /// Holds transactional information about this cancellation.
    /// </summary>
    public ITransactionResponse Cancellation { get; }
}