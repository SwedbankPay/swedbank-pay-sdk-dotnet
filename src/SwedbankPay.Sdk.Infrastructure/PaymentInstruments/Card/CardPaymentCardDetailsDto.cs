namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentCardDetailsDto
    {
        public CardPaymentCardDetailsDto(ICardPaymentCardDetails transaction)
        {
            CardExpiryMonth = transaction.CardExpiryMonth;
            CardExpiryYear = transaction.CardExpiryYear;
            CardHolderName = transaction.CardHolderName;
            CardNumber = transaction.CardNumber;
            CardVerificationCode = transaction.CardVerificationCode;
        }

        public int CardExpiryMonth { get; }

        public int CardExpiryYear { get; }

        public string CardHolderName { get; }

        public string CardNumber { get; }

        public string CardVerificationCode { get; }
    }
}