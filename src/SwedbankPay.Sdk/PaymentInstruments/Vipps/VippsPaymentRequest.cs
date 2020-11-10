using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentRequest
    {
        public VippsPaymentRequest(Operation operation,
                              PaymentIntent intent,
                              CurrencyCode currency,
                              List<IPrice> prices,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              string payerReference,
                              bool generatePaymentToken = false,
                              bool generateReccurenceToken = false,
                              Dictionary<string, object> metadata = null,
                              string paymentToken = null)

        {
            Payment = new VippsPaymentRequestData(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               generateReccurenceToken, userAgent, language, urls, payeeInfo, metadata, paymentToken);
        }


        public VippsPaymentRequestData Payment { get; }
    }
}