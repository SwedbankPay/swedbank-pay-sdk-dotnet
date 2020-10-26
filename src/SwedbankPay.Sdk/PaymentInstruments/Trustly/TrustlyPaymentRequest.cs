using SwedbankPay.Sdk.Common;
using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentInstruments.Trustly
{
    public class TrustlyPaymentRequest
    {
        public TrustlyPaymentRequest(
            CurrencyCode currency,
            List<IPrice> prices,
            string description,
            string payerReference,
            string userAgent,
            CultureInfo language,
            IUrls urls,
            PayeeInfo payeeInfo,
            TrustlyPrefillInfo prefillInfo)
        {
            Payment = new TrustlyPaymentRequestObject(currency, prices, description, payerReference, userAgent, language,
                                               urls, payeeInfo, prefillInfo);
        }


        public TrustlyPaymentRequestObject Payment { get; }
    }
}