using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.Payments.TrustlyPayments
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
            PayeeInfo payeeInfo) : this(currency, prices, description, payerReference, userAgent, language, urls, payeeInfo, null)
        {
        }


        public TrustlyPaymentRequest(
            CurrencyCode currency,
            List<IPrice> prices,
            string description,
            string payerReference,
            string userAgent,
            CultureInfo language,
            IUrls urls,
            PayeeInfo payeeInfo,
            PrefillInfo prefillInfo)
        {
            Payment = new PaymentRequestObject(currency, prices, description, payerReference, userAgent, language,
                                               urls, payeeInfo, prefillInfo);
        }


        public PaymentRequestObject Payment { get; }
    }

    public class PaymentRequestObject
    {
        protected internal PaymentRequestObject(CurrencyCode currency,
                                                List<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                string userAgent,
                                                CultureInfo language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo) : this(currency, prices, description, payerReference, userAgent, language, urls, payeeInfo, null)
        {
        }

        protected internal PaymentRequestObject(CurrencyCode currency,
                                                List<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                string userAgent,
                                                CultureInfo language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo,
                                                PrefillInfo prefillInfo)
        {
            Operation = Operation.Purchase;
            Intent = PaymentIntent.Sale;
            Currency = currency;
            Prices = prices;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            PrefillInfo = prefillInfo;
        }


        public CurrencyCode Currency { get; set; }
        public string Description { get; set; }
        public PaymentIntent Intent { get; set; }
        public CultureInfo Language { get; set; }
        public Operation Operation { get; set; }
        public PayeeInfo PayeeInfo { get; internal set; }
        public string PayerReference { get; set; }
        public List<IPrice> Prices { get; set; }
        public IUrls Urls { get; }
        public string UserAgent { get; set; }
        public PrefillInfo PrefillInfo { get; set; }
    }
}