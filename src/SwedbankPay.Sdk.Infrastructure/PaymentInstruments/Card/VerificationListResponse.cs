using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class VerificationListResponse : Identifiable, IVerificationListResponse
    {
        public VerificationListResponse(Uri id, IList<VerificationDto> verificationList)
            :base(id)
        {
            foreach (var item in verificationList)
            {
                VerificationList.Add(new CardPaymentVerification(item));
            }
        }

        public IList<ICardPaymentVerification> VerificationList { get; } = new List<ICardPaymentVerification>();
    }
}