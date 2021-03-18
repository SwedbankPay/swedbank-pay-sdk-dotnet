namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Used to verify a payment.
    /// </summary>
    public class CardPaymentVerifyRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="CardPaymentRequest"/> using the provided parameters.
        /// </summary>
        /// <param name="intent">The initial intent of this payment.</param>
        /// <param name="currency">The wanted <seealso cref="Currency"/> for the payment to be paid in.</param>
        /// <param name="description">A textual description of the payment.</param>
        /// <param name="userAgent">The payers UserAgent.</param>
        /// <param name="language">The prefered <seealso cref="Language"/> of the payer.</param>
        /// <param name="urls">Object holding relevant <seealso cref="IUrls"/> for the payment.</param>
        /// <param name="payeeInfo">Object identifying the payee.</param>
        public CardPaymentVerifyRequest(PaymentIntent intent,
                              Currency currency,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              IPayeeInfo payeeInfo)
        {
            Payment = new CardPaymentVerifyRequestDetails(intent, currency, description,
                                               userAgent, language, urls, payeeInfo);
        }

        /// <summary>
        /// Detailed information about this card payment.
        /// </summary>
        public CardPaymentVerifyRequestDetails Payment { get; }
    }
}