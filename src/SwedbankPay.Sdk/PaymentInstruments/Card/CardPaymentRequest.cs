using SwedbankPay.Sdk.PaymentOrders;
using System.Collections.Generic;

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
        /// <param name="prices">Prices shows different prices for different payment options.</param>
        /// <param name="description">A textual description of the payment.</param>
        /// <param name="userAgent">The payers UserAgent.</param>
        /// <param name="language">The prefered <seealso cref="Language"/> of the payer.</param>
        /// <param name="urls">Object holding relevant <seealso cref="IUrls"/> for the payment.</param>
        /// <param name="payeeInfo">Object identifying the payee.</param>
        /// <param name="generatePaymentToken">Set if you want a payment token to be generated for later use.</param>
        /// <param name="generateRecurrenceToken">Set if you want a recurrence token to be generated for later use.</param>
        /// <param name="payerReference">A reference for the payer in your systems.</param>
        /// <param name="riskIndicator">Object that reduces the amount of risk of the payment the more details is has.</param>
        /// <param name="cardholder">Information about the card holder.</param>
        /// <param name="creditCard">Information about the credt card to be used.</param>
        /// <param name="metadata">Meta data relevant for the payment.</param>
        /// <param name="paymentToken">A previously generated payment token.</param>
        public CardPaymentRequest(Operation operation,
                              PaymentIntent intent,
                              Currency currency,
                              List<IPrice> prices,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              bool generatePaymentToken = false,
                              bool generateRecurrenceToken = false,
                              string payerReference = null,
                              IRiskIndicator riskIndicator = null,
                              Cardholder cardholder = null,
                              PaymentOrderCreditCardOptions creditCard = null,
                              MetadataResponse metadata = null,
                              string paymentToken = null)
        {
            Payment = new CardPaymentDetails(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateRecurrenceToken, userAgent, language, urls, payeeInfo, riskIndicator, cardholder,
                                               creditCard, metadata, paymentToken);
        }

        /// <summary>
        /// Detailed information about this card payment.
        /// </summary>
        public CardPaymentDetails Payment { get; }
    }
}