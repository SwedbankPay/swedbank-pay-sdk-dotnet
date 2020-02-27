using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments.SwishPayments
{
    public class SwishPaymentRequest
    {
        public SwishPaymentRequest(CurrencyCode currency,
                              List<Price> prices,
                              string description,
                              string payerReference,
                              string userAgent,
                              CultureInfo language,
                              Urls urls,
                              PayeeInfo payeeInfo,
                              PrefillInfo prefillInfo,
                              bool isEnabledForEcommerceOnly = false,
                              Dictionary<string, object> metadata = null)
        {
            var swishRequest = new SwishPaymentOptionsObject(isEnabledForEcommerceOnly);
            Payment = new SwishPaymentRequestObject(currency, prices, description, payerReference, userAgent, language, urls, payeeInfo,
                                               prefillInfo, swishRequest, metadata);
        }


        public SwishPaymentRequestObject Payment { get; }
    }
}