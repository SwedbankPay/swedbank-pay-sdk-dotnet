using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Object describing a verified card payment.
    /// </summary>
    public interface ICardPaymentVerifications: IIdentifiable
    {
        /// <summary>
        /// List of available <seealso cref="ICardPaymentVerification"/>.
        /// </summary>
        IList<ICardPaymentVerification> VerificationList { get; }
    }
}