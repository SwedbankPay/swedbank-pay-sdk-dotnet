using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    /// <summary>
    /// Wrapper for creating a Swish payment request.
    /// </summary>
    public class SwishPaymentRequest
    {
        /// <summary>
        /// Instantiates a new <see cref="SwishPaymentRequest"/> with the provided parameters.
        /// </summary>
        /// <param name="prices">List of prices object to give discounts.</param>
        /// <param name="description">Textual description of the payment.</param>
        /// <param name="payerReference">Refence to the payer in the merchant systems.</param>
        /// <param name="userAgent">The UserAgent string of the payers device.</param>
        /// <param name="language">The payers prefered langauge.</param>
        /// <param name="urls">Object describing relevant URLs for this payment.</param>
        /// <param name="payeeInfo">Object holding information about the merchant-</param>
        /// <param name="prefillInfo">Known information about the payer than can be
        /// pre-filled in the payment window.</param>
        public SwishPaymentRequest(IEnumerable<IPrice> prices,
                              string description,
                              string payerReference,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              PrefillInfo prefillInfo)
        {
            var swishRequest = new SwishRequestData();
            Payment = new SwishPaymentRequestDetails(prices, description, payerReference, userAgent, language, urls, payeeInfo, prefillInfo, swishRequest);
        }

        /// <summary>
        /// Details on what to be included in the payment.
        /// </summary>
        public SwishPaymentRequestDetails Payment { get; }
    }
}