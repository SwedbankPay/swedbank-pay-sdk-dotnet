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
        /// <param name="cardVerificationCode">The payers card verification code.</param>
        /// <param name="cardHolderName">The payers card holder name.</param>
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
        /// Transactional details on the card payment.
        /// </summary>
        public ICardPaymentCardDetails Transaction { get; }
    }
}