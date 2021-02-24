using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Detailed information about verified card payments.
    /// </summary>
    public interface ICardPaymentVerifyResponseDetails: IIdentifiable
    {
        /// <summary>
        /// List of available verifications.
        /// </summary>
        IList<ICardPaymentVerification> VerificationList { get; }
    }
}