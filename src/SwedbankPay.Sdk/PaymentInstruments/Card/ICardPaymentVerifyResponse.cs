using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Response of verifying a card payment.
    /// </summary>
    public interface ICardPaymentVerifyResponse : IIdentifiable
    {
        /// <summary>
        /// Available list of verifications.
        /// </summary>
        IList<ICardPaymentAuthorization> VerificationList { get; }
    }
}