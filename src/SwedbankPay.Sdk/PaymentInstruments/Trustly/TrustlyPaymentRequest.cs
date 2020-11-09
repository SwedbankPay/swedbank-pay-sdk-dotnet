using System.Collections.Generic;

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
            Language language,
            IUrls urls,
            PayeeInfo payeeInfo,
            TrustlyPrefillInfo prefillInfo = null)
        {
            Payment = new TrustlyPayment(currency, prices, description, payerReference, userAgent, language,
                                               urls, payeeInfo, prefillInfo);
        }


        public TrustlyPayment Payment { get; }
    }
}