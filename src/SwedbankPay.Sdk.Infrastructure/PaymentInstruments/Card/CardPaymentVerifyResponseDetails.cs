using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card;

internal class CardPaymentVerifyResponseDetails : Identifiable, ICardPaymentVerifyResponseDetails
{
    public CardPaymentVerifyResponseDetails(Uri id, IList<CardPaymentVerificationDto> verificationList)
        :base(id)
    {
        foreach (var item in verificationList)
        {
            VerificationList.Add(new CardPaymentVerification(item));
        }
    }

    public IList<ICardPaymentVerification> VerificationList { get; } = new List<ICardPaymentVerification>();
}