namespace SwedbankPay.Sdk.PaymentInstruments.Card
{
    /// <summary>
    /// Class to hold details about a card payment request.
    /// </summary>
    public class CardPaymentRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="CardPaymentRequest"/> using the provided parameters.
        /// </summary>
        /// <param name="operation">The initial <see cref="Operation"/> for the request.</param>
        /// <param name="intent">The initial intent of this payment.</param>
        /// <param name="currency">The wanted <seealso cref="Currency"/> for the payment to be paid in.</param>
        /// <param name="description">A textual description of the payment.</param>
        /// <param name="userAgent">The payers UserAgent.</param>
        /// <param name="language">The preferred <seealso cref="Language"/> of the payer.</param>
        /// <param name="urls">Object holding relevant <seealso cref="IUrls"/> for the payment.</param>
        /// <param name="payeeInfo">Object identifying the payee.</param>
        public CardPaymentRequest(Operation operation,
                              PaymentIntent intent,
                              Currency currency,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              IPayeeInfo payeeInfo)
        {
            Payment = new CardPaymentDetails(operation, intent, currency, description,  
                                               userAgent, language, urls, payeeInfo);
        }

        /// <summary>
        /// Detailed information about this card payment.
        /// </summary>
        public CardPaymentDetails Payment { get; }
    }
}