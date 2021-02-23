using System.Collections;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public interface ICardPaymentVerifyResponseDetails: IIdentifiable
    {
        IList<ICardPaymentVerification> VerificationList { get; }
    }
}