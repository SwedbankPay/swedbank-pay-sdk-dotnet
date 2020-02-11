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
                              SwishRequest swishRequest,
                              Dictionary<string, object> metaData = null)
        {
            Payment = new SwishPaymentPaymentRequestObject(currency, prices, description, payerReference, userAgent, language, urls, payeeInfo,
                                               prefillInfo, swishRequest, metaData);
        }


        public SwishPaymentPaymentRequestObject Payment { get; }
    }
}