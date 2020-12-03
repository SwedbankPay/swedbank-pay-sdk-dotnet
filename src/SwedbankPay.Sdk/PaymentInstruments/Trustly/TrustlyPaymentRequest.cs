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
        /// <param name="description">Textual descroption of the payment.</param>
        /// <param name="payerReference">A reference to the payer in the merchant system.</param>
        /// <param name="userAgent">The payers UserAgent string.</param>
        /// <param name="language">The payers prefered language.</param>
        /// <param name="urls">Object holding relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Object with merchant information.</param>
        /// <param name="prefillInfo">Relevant information about the payer to pre-fill payment window.</param>
        public TrustlyPaymentRequest(
            Currency currency,
            List<IPrice> prices,
            string description,
            string payerReference,
            string userAgent,
            Language language,
            IUrls urls,
            PayeeInfo payeeInfo,
            TrustlyPrefillInfo prefillInfo = null)
        {
            Payment = new TrustlyPaymentDetails(currency, prices, description, payerReference, userAgent, language,
                                               urls, payeeInfo, prefillInfo);
        }

        /// <summary>
        /// Data related to a Trustly payment.
        /// </summary>
        public TrustlyPaymentDetails Payment { get; }
    }
}