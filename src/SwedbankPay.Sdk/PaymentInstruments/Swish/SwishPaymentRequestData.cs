using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.Swish
{
    public class SwishPaymentRequestData
    {
        protected internal SwishPaymentRequestData(CurrencyCode currency,
                                                List<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                string userAgent,
                                                Language language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo,
                                                PrefillInfo prefillInfo,
                                                SwishPaymentOptions swishRequest,
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
        public Language Language { get; }
        public Operation Operation { get; }
        public PayeeInfo PayeeInfo { get; }
        public string PayerReference { get; }
        public PrefillInfo PrefillInfo { get; }
        public List<IPrice> Prices { get; }
        public SwishPaymentOptions Swish { get; }
        public IUrls Urls { get; }
        public string UserAgent { get; }
        public Dictionary<string, object> Metadata { get; }
    }
}