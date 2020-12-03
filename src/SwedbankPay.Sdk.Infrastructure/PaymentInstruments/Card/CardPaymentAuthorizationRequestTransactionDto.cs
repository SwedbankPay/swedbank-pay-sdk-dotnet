namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    internal class CardPaymentAuthorizationRequestTransactionDto
    {
        public int CardExpiryMonth { get; }
        public int CardExpiryYear { get; }
        public string CardHolderName { get; }
        public string CardNumber { get; }
        public string CardVerificationCode { get; }

        internal CardPaymentCardDetails Map()
        {
            return new CardPaymentCardDetails(
                CardNumber,
                CardExpiryMonth,
                CardExpiryYear,
                CardVerificationCode,
                CardHolderName
                );
        }
    }
}