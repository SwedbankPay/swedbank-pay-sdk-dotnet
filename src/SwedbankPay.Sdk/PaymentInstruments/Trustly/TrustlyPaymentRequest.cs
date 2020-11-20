using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentRequest
    {
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