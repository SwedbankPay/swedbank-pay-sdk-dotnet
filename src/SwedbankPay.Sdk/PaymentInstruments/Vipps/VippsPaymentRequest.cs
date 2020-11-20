using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Vipps
{
    public class VippsPaymentRequest
    {
        public VippsPaymentRequest(Operation operation,
                              PaymentIntent intent,
                              Currency currency,
                              List<IPrice> prices,
                              string description,
                              string userAgent,
                              Language language,
                              IUrls urls,
                              PayeeInfo payeeInfo,
                              string payerReference,
                              bool generatePaymentToken = false,
                              bool GenerateRecurrenceToken = false,
                              Dictionary<string, object> metadata = null,
                              string paymentToken = null)

        {
            Payment = new VippsPaymentRequestDetails(operation, intent, currency, prices, description, payerReference, generatePaymentToken,
                                               GenerateRecurrenceToken, userAgent, language, urls, payeeInfo, metadata, paymentToken);
        }

        /// <summary>
        /// Details for creating a Vipps payment.
        /// </summary>
        public VippsPaymentRequestDetails Payment { get; }
    }
}