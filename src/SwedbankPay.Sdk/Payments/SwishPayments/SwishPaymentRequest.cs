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
                              Dictionary<string, object> metaData = null)
        {
            var swishRequest = new SwishPaymentOptionsObject(isEnabledForEcommerceOnly);
            Payment = new SwishPaymentRequestObject(currency, prices, description, payerReference, userAgent, language, urls, payeeInfo,
                                               prefillInfo, swishRequest, metaData);
        }


        public SwishPaymentRequestObject Payment { get; }
    }
}