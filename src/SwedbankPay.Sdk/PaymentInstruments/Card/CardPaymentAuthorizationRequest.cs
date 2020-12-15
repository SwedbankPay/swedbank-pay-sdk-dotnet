namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Holds details about a card payment authorization request.
    /// </summary>
    public class CardPaymentAuthorizationRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="CardPaymentAuthorizationRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="cardNumber">The payers card number.</param>
        /// <param name="cardExpiryMonth">The payers card expiry month.</param>
        /// <param name="cardExpiryYear">The payers card expiry year.</param>
        public CardPaymentAuthorizationRequest(string cardNumber,
                                    int cardExpiryMonth,
                                    int cardExpiryYear)
        {
            Transaction = new CardPaymentCardDetails(cardNumber,
                                                    cardExpiryMonth,
                                                    cardExpiryYear);
        }

        /// <summary>
        /// Transactional details on the card payment.
        /// </summary>
        public ICardPaymentCardDetails Transaction { get; }
    }
}