namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    public class CardPaymentAuthorizationRequest
    {
        public CardPaymentAuthorizationRequest(string cardNumber,
                                    int cardExpiryMonth,
                                    int cardExpiryYear,
                                    string cardVerificationCode = null,
                                    string cardHolderName = null)
        {
            Transaction = new CardPaymentCardDetails(cardNumber,
                                                                         cardExpiryMonth,
                                                                         cardExpiryYear,
                                                                         cardVerificationCode,
                                                                         cardHolderName);
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public ICardPaymentCardDetails Transaction { get; }
    }
}