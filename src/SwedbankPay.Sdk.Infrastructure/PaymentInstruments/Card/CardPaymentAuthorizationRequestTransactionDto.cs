using System;

namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAuthorizationRequestTransactionDto
    {
        public int CardExpiryMonth { get; }
        public int CardExpiryYear { get; }
        public string CardHolderName { get; }
        public string CardNumber { get; }
        public string CardVerificationCode { get; }

        internal CardPaymentAuthorizationRequestTransaction Map()
        {
            return new CardPaymentAuthorizationRequestTransaction(
                CardNumber,
                CardExpiryMonth,
                CardExpiryYear,
                CardVerificationCode,
                CardHolderName
                );
        }
    }
}