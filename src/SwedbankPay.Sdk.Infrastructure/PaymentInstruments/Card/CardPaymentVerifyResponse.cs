using System;
using System.Collections.Generic;
using System.Text;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentVerifyResponse : Identifiable, ICardPaymentVerifyResponse
    {
        public CardPaymentVerifyResponse(Uri id, IList<ICardPaymentAuthorization> verificationList)
            : base(id)
        {
            VerificationList = verificationList ?? throw new ArgumentNullException(nameof(verificationList));
        }

        public IList<ICardPaymentAuthorization> VerificationList { get; }
    }
}
