using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    /// <summary>
    /// Object to create a payment for Vipps.
    /// </summary>
    public class VippsPaymentRequest
    {
        /// <summary>
        /// Instantiates a <see cref="VippsPaymentRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="operation">The initial operation of this payment.</param>
        /// <param name="intent">The intent of this payment.</param>
        /// <param name="currency">The wanted currency of the payment.</param>
        /// <param name="prices">List of payment instrument prices.</param>
        /// <param name="description">Textual description of the payment.</param>
        /// <param name="payerReference">Merchant reference to the payer.</param>
        /// <param name="generatePaymentToken">Set if you want a payment token to be generated for later use.</param>
        /// <param name="generateRecurrenceToken">Set if you want a recurrence token to be generated for later use.</param>
        /// <param name="userAgent">The payers UserAgent string.</param>
        /// <param name="language">The payers prefered language.</param>
        /// <param name="urls">Object with relevant URLs for the payment.</param>
        /// <param name="payeeInfo">Object with information about the merchant.</param>
        /// <param name="metadata">MetaData to be stored with the payment.</param>
        /// <param name="paymentToken">A previously generated payment token. See <paramref name="generatePaymentToken"/>.</param>
        public VippsPaymentRequest(Operation operation,
                              PaymentIntent intent,
                              Currency currency,
                              List<IPrice> prices,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              string payerReference,
                              bool generatePaymentToken = false,
                              bool generateRecurrenceToken = false,
                              Dictionary<string, object> metadata = null,
                              string paymentToken = null)

        {
            Payment = new VippsPaymentRequestDetails(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateRecurrenceToken, userAgent, language, urls, payeeInfo, metadata, paymentToken);
        }

        /// <summary>
        /// Details for creating a Vipps payment.
        /// </summary>
        public VippsPaymentRequestDetails Payment { get; }
    }
}