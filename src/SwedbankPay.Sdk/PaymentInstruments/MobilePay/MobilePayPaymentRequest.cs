using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentRequest
    {
        public MobilePayPaymentRequest(Operation operation,
                              PaymentIntent intent,
                              CurrencyCode currency,
                              List<IPrice> prices,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              Uri shopslogoUrl,
                              string payerReference = null,
                              Dictionary<string, object> metadata = null,
                              PrefillInfo prefillInfo = null)

        {
            Payment = new MobilePayPayment(operation, intent, currency, prices, description, payerReference, userAgent, language, urls, payeeInfo, metadata, prefillInfo);
            MobilePay = new MobilePayPaymentRequestData(shopslogoUrl);
        }


        public MobilePayPayment Payment { get; }
        public MobilePayPaymentRequestData MobilePay { get; }
    }
}
