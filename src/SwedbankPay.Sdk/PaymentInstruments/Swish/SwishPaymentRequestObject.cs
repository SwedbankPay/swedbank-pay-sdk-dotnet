using System.Collections.Generic;
using System.Globalization;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentRequestObject
    {
        protected internal SwishPaymentRequestObject(CurrencyCode currency,
                                                List<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                string userAgent,
                                                CultureInfo language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo,
                                                PrefillInfo prefillInfo,
                                                SwishPaymentOptionsObject swishRequest,
                                                Dictionary<string, object> metadata = null)
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
            Swish = swishRequest;
            Metadata = metadata;
        }



        public CurrencyCode Currency { get; }
        public string Description { get; }
        public PaymentIntent Intent { get; }
        public CultureInfo Language { get; }

        public Operation Operation { get; }
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public PrefillInfo PrefillInfo { get; }
        public List<IPrice> Prices { get; }

        public SwishPaymentOptionsObject Swish { get; }

        public IUrls Urls { get; }
        public string UserAgent { get; }
        public Dictionary<string, object> Metadata { get; }
    }
}