using System;
using System.Collections.Generic;

namespace SwedbankPay.Sdk.PaymentInstruments.MobilePay
{
    public class MobilePayPaymentData : IMobilePayPaymentData
    {
        public MobilePayPaymentData(Operation operation,
                                                PaymentIntent intent,
                                                CurrencyCode currency,
                                                List<IPrice> prices,
                                                string description,
                                                string payerReference,
                                                string userAgent,
                                                Language language,
                                                IUrls urls,
                                                PayeeInfo payeeInfo,
                                                MetadataResponse metadata = null,
                                                PrefillInfo prefillInfo = null)
        {
            Operation = operation ?? throw new ArgumentNullException(nameof(operation));
            Intent = intent;
            Currency = currency;
            Prices = prices;
            Description = description;
            PayerReference = payerReference;
            UserAgent = userAgent;
            Language = language;
            Urls = urls;
            PayeeInfo = payeeInfo;
            Metadata = metadata;
            PrefillInfo = prefillInfo;
        }


        public CurrencyCode Currency { get; set; }
        public string Description { get; set; }
        public PaymentIntent Intent { get; set; }
        public Language Language { get; set; }
        public Operation Operation { get; set; }
        public PayeeInfo PayeeInfo { get; set; }
        public string PayerReference { get; set; }
        public List<IPrice> Prices { get; set; }
        public IUrls Urls { get; }
        public string UserAgent { get; set; }
        public PrefillInfo PrefillInfo { get; set; }
        public MetadataResponse Metadata { get; }
    }
}
