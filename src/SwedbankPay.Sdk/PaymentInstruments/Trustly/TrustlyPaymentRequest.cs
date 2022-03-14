using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    /// <summary>
    /// Request details for creating a Trustly payment.
    /// </summary>
    public class TrustlyPaymentRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="TrustlyPaymentRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="currency">The wanted currency of the payment.</param>
        /// <param name="prices">Prices object describing the payment price with different payment methods.</param>
        /// <param name="description">Textual description of the payment.</param>
        /// <param name="payerReference">A reference to the payer in the merchant system.</param>
        /// <param name="language">The payers preferred <seealso cref="Sdk.Language"/>.</param>
        /// <param name="urls">Object holding relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Object with merchant information.</param>
        public TrustlyPaymentRequest(
            Currency currency,
            IEnumerable<IPrice> prices,
            string description,
            string payerReference,
            Language language,
            IUrls urls,
            IPayeeInfo payeeInfo) : this(currency, prices, description, payerReference, null, language, urls, payeeInfo)
        {
        }

        /// <summary>
        /// Instantiates a new <see cref="TrustlyPaymentRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="currency">The wanted currency of the payment.</param>
        /// <param name="prices">Prices object describing the payment price with different payment methods.</param>
        /// <param name="description">Textual description of the payment.</param>
        /// <param name="payerReference">A reference to the payer in the merchant system.</param>
        /// <param name="userAgent">The payers UserAgent string.</param>
        /// <param name="language">The payers preferred <seealso cref="Sdk.Language"/>.</param>
        /// <param name="urls">Object holding relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Object with merchant information.</param>
        public TrustlyPaymentRequest(
            Currency currency,
            IEnumerable<IPrice> prices,
            string description,
            string payerReference,
            string userAgent,
            Language language,
            IUrls urls,
            IPayeeInfo payeeInfo)
        {
            Payment = new TrustlyPaymentDetails(currency, prices, description, payerReference, userAgent, language,
                                               urls, payeeInfo);
        }

        /// <summary>
        /// Data related to a Trustly payment.
        /// </summary>
        public TrustlyPaymentDetails Payment { get; }
    }
}