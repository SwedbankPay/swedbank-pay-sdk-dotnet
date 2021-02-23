using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentVerifications
    {
        IIdentifiable Id { get; }

        IList<ICardPaymentVerification> VerificationList { get; }
    }
}