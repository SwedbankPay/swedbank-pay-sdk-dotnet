using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Transactional details about a credit card authorization.
    /// </summary>
    public interface ICardPaymentAuthorizationResponse
    {
        /// <summary>
        /// Transactional details about the authorization.
        /// </summary>
        ICardPaymentAuthorization Authorization { get; }

        /// <summary>
        /// A unique <seealso cref="Uri"/> to access this authorization.
        /// </summary>
        Uri Payment { get; }
    }
}