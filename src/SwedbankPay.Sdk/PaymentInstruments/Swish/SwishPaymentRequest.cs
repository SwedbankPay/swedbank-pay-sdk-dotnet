using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentRequest
    {
        public SwishPaymentRequest(CurrencyCode currency,
                              List<IPrice> prices,
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
            Payment = new SwishPaymentRequestData(currency, prices, description, payerReference, userAgent, language, urls, payeeInfo,
                                               prefillInfo, swishRequest, metadata);
        }


        public SwishPaymentRequestData Payment { get; }
    }
}