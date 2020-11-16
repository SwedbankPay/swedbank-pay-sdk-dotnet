using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentRequest
    {
        public SwishPaymentRequest(List<IPrice> prices,
                              string description,
                              string payerReference,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              PrefillInfo prefillInfo,
                              bool isEnabledForEcommerceOnly = false,
                              Dictionary<string, object> metadata = null)
        {
            var swishRequest = new SwishPaymentOptions(isEnabledForEcommerceOnly);
            Payment = new SwishPaymentRequestData(prices, description, payerReference, userAgent, language, urls, payeeInfo, prefillInfo,
                                               swishRequest, metadata);
        }

        /// <summary>
        /// Details on what to be included in the payment.
        /// </summary>
        public SwishPaymentRequestData Payment { get; }
    }
}